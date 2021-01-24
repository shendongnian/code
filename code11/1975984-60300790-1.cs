    using MongoDB.Entities;
    using MongoDB.Entities.Core;
    using System;
    using System.Linq;
    namespace StackOverFlow
    {
        public class Customer : Entity
        {
            public Item[] Items { get; set; }
        }
        public class Item
        {
            public Source Source { get; set; }
        }
        public class Source
        {
            public CustomerInfo CustomerInfo { get; set; }
        }
        public class CustomerInfo
        {
            public string CustomerID { get; set; }
            public string CustomerName { get; set; }
        }
        public static class Program
        {
            private static void Main()
            {
                new DB("test");
                var customer = new Customer
                {
                    Items = new[]
                    {
                        new Item
                        {
                            Source = new Source {
                                CustomerInfo = new CustomerInfo
                                {
                                    CustomerID = "xxxxxxx",
                                    CustomerName = "customer one"
                                }
                            }
                        }
                    }
                };
                customer.Save();
                var result = DB.Queryable<Customer>()
                               .Select(c => c.Items[0].Source.CustomerInfo)
                               .ToArray();
                foreach (var info in result)
                {
                    Console.WriteLine($"id: {info.CustomerName} / name: {info.CustomerName}");
                }
                Console.ReadKey();
            }
        }
    }
above test program uses my library MongoDB.Entities for brevity. if you're overwhelmed by the verbosity of the official driver, you might want to check out my library.
