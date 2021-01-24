    using MongoDB.Entities;
    using MongoDB.Entities.Core;
    using System;
    using System.Linq;
    namespace StackOverflow
    {
        public class Product : Entity
        {
            public DateTime DateUpdated { get; set; }
            public string CategoryID { get; set; }
        }
        public class ProductCategory : Entity
        {
            public bool Active { get; set; }
        }
        public class Program
        {
            private static void Main(string[] args)
            {
                new DB("test", "localhost");
                var cat1 = new ProductCategory { Active = true }; cat1.Save();
                var cat2 = new ProductCategory { Active = true }; cat2.Save();
                (new[] { new Product
                {
                    CategoryID = cat1.ID,
                    DateUpdated = DateTime.UtcNow.AddDays(-1.5)
                },
                new Product
                {
                    CategoryID = cat2.ID,
                    DateUpdated = DateTime.UtcNow
                }}).Save(); ;
                var inactiveCatIDs = DB.Queryable<Product>()
                                       .Where(p => p.DateUpdated <= DateTime.UtcNow.AddDays(-1))
                                       .Select(p => p.CategoryID)
                                       .ToArray();
                DB.Update<ProductCategory>()
                  .Match(c => inactiveCatIDs.Contains(c.ID))
                  .Modify(c => c.Active, false)
                  .Execute();
            }
        }
    }
