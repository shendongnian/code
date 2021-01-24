    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Core.Objects.DataClasses;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace EntityCollectionTesting
    {
        class Program
        {
            static void Main(string[] args)
            {
                var productList =
                        new List<Product> {
                        new Product { ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.0000M, UnitsInStock = 39 },
                        new Product { ProductID = 2, ProductName = "Chang", Category = "Beverages", UnitPrice = 19.0000M, UnitsInStock = 17 },
                        new Product { ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10.0000M, UnitsInStock = 13 },
                        new Product { ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", Category = "Condiments", UnitPrice = 22.0000M, UnitsInStock = 53 },
                        new Product { ProductID = 5, ProductName = "Chef Anton's Gumbo Mix", Category = "Condiments", UnitPrice = 21.3500M, UnitsInStock = 0 },
                        new Product { ProductID = 6, ProductName = "Grandma's Boysenberry Spread", Category = "Condiments", UnitPrice = 25.0000M, UnitsInStock = 120 },
                        new Product { ProductID = 7, ProductName = "Uncle Bob's Organic Dried Pears", Category = "Produce", UnitPrice = 30.0000M, UnitsInStock = 15 },
                        new Product { ProductID = 8, ProductName = "Northwoods Cranberry Sauce", Category = "Condiments", UnitPrice = 40.0000M, UnitsInStock = 6 },
                        new Product { ProductID = 9, ProductName = "Mishi Kobe Niku", Category = "Meat/Poultry", UnitPrice = 97.0000M, UnitsInStock = 29 },
                        new Product { ProductID = 10, ProductName = "Ikura", Category = "Seafood", UnitPrice = 31.0000M, UnitsInStock = 31 },
                        new Product { ProductID = 1, ProductName = "Ikura", Category = "Seafood", UnitPrice = 31.0000M, UnitsInStock = 40 },
                        new Product { ProductID = 2, ProductName = "Ikura", Category = "Seafood", UnitPrice = 31.0000M, UnitsInStock = 56 },
                        new Product { ProductID = 3, ProductName = "Ikura", Category = "Seafood", UnitPrice = 31.0000M, UnitsInStock = 11 },
                        new Product { ProductID = 4, ProductName = "Ikura", Category = "Seafood", UnitPrice = 31.0000M, UnitsInStock = 12 },
                        new Product { ProductID = 5, ProductName = "Ikura", Category = "Seafood", UnitPrice = 31.0000M, UnitsInStock = 1 }                       
                        
                    };
    
                EntityCollection<Product> entityCollection = new EntityCollection<Product>();
                EntityCollection<Product> newCollection = new EntityCollection<Product>();
    
                foreach (var VARIABLE in productList)
                {
                    entityCollection.Add(VARIABLE);
                    newCollection.Add(VARIABLE);
                }
    
                foreach (var ec in entityCollection)
                {
                    foreach (var nc in newCollection)
                    {
                        if (ec.ProductID == nc.ProductID)
                        {
                            if (ec.UnitsInStock > nc.UnitsInStock)
                            {
                                newCollection.Remove(nc);
    
                                break;
                            }
                        }
                    }
                }
                foreach (var VARIABLE in newCollection)
                {
                    Console.WriteLine($"{VARIABLE.ProductID} and {VARIABLE.UnitsInStock}");
                }
    
                Console.ReadLine();
            }
        }
        public class Product
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public string Category { get; set; }
            public decimal UnitPrice { get; set; }
            public int UnitsInStock { get; set; }
        }
    }
