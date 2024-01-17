using System.ComponentModel;
using System.IO;

namespace CSharpDay2Assignment
{
    internal class Program
    {
        public enum UserType
        {
            admin = 1,
            customer
        }

        public enum AdminChoice
        {
            addProducts = 1,
            displayproducts
        }
       
        public enum CustomerChoice
        {
            orderProduct = 1,
            showBill
        }
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            List<Product> cart = new List<Product>();
            bool flag = true;
            while (flag == true)
            {
                Console.WriteLine("Enter type of user 1: admin 2: customer 3 : exit");
                byte type = Convert.ToByte(Console.ReadLine());
                switch (type)
                {
                    case (byte)UserType.admin:
                        bool flag2 = true;
                        while (flag2)
                        {
                            Console.WriteLine("Enter Choice 1:Addproduct  2:Display products 3.exit");
                            byte choice = Convert.ToByte(Console.ReadLine());
                            switch (choice)
                            {
                                case (byte)AdminChoice.addProducts:
                                    Product product = new();
                                    product.Getdetails();
                                    products.Add(product);
                                    product.DisplayDetails();
                                    break;
                                case (byte)AdminChoice.displayproducts:
                                    foreach (Product p in products)
                                    {
                                        Console.WriteLine();
                                        p.DisplayDetails();
                                    }
                                    break;
                                default:
                                    flag2 = false;
                                    break;
                            }
                        }
                        break;
                    case (byte)UserType.customer:
                        bool flag3 = true;
                        while (flag3)
                        {
                            Console.WriteLine("Enter Choice 1:Order Product  2:Get Bill 3: exit ");
                            byte choice1 = Convert.ToByte(Console.ReadLine());
                            switch (choice1)
                            {
                                case (byte)CustomerChoice.orderProduct:
                                    Console.WriteLine("Enter product name");
                                    string productName = Console.ReadLine();
                                    Product? p1 = products.Find(x => x.pname.Contains(productName));
                                    if (p1 == null)
                                    {
                                        Console.WriteLine("product Not found");
                                    }
                                    else
                                    {
                                        p1.DisplayDetails();
                                        if (p1.qty_in_stock == 0)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("No quantity available");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Want to buy ? 1 : yes 2 : no");
                                            byte c = Convert.ToByte(Console.ReadLine());
                                            if (c == 1)
                                            {
                                                cart.Add(p1);
                                                Console.WriteLine("Product added to cart");
                                                p1.qty_in_stock--;
                                            }
                                        }
                                    }
                                    break;
                                case (byte)CustomerChoice.showBill:
                                    double sum = 0;
                                    foreach (Product p in cart)
                                    {
                                        Console.WriteLine("Following are products in cart :");
                                        if (DateTime.Now.Day == 26 && DateTime.Now.Month == 1)
                                        {
                                            Console.WriteLine($" Product Name : {p.pname} Discounted Price of product : {(p.price - (p.price * 0.5))} ");
                                            sum += (p.price - (p.price * 0.5));
                                        }
                                        else
                                        {
                                            Console.WriteLine($" Product Name : {p.pname} Discounted Price of product : {(p.price - (p.price * (p.discount_allowed / 100)))} ");
                                            sum += (p.price - (p.price * (p.discount_allowed / 100.0f)));
                                        }
                                    }
                                    Console.WriteLine("Total bill is :" + sum);
                                    break;
                                default:
                                    flag3 = false;
                                    break;
                            }
                        }

                        break;
                    default:
                        Console.WriteLine("Exited");
                        flag = false;
                        break;
                }
            }
        }

    }

        public class Product
        {
            readonly int pcode;
            public string? pname;
            public int qty_in_stock;
            public double discount_allowed;
            static string brand;
            public double price;

            public Product()
            {
                Console.WriteLine("Enter Pcode");
                this.pcode = Convert.ToInt32(Console.ReadLine());
            }

            static Product()
            {
                brand = "Lewis";
            }

            public void Getdetails()
            {
                Console.WriteLine("Enter PName");
                this.pname = Console.ReadLine();
                Console.WriteLine("Enter Price");
                this.price = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter Qty in stocks");
                this.qty_in_stock = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Discount Allowed");
                this.discount_allowed = Convert.ToInt32(Console.ReadLine());
            }

            public void DisplayDetails()
            {
                Console.WriteLine($"Pcode is : {this.pcode}");
                Console.WriteLine($"PName is : {this.pname}");
                Console.WriteLine($"Brand is : {brand}");
                Console.WriteLine($"Price is : {this.price}");
                Console.WriteLine($"Qauntity in stock is : {this.qty_in_stock}");
                Console.WriteLine($"Discount Allowed is : {this.discount_allowed}");
            }
        }
    }
