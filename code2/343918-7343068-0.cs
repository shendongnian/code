    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Review
    {
        public string Value1;
    }
    class Product
    {
        public DateTime Value2;
    }
    class Page
    {
        public int Value3;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var reviews = new List<Review>
            {
                new Review { Value1 = "123" },
                new Review { Value1 = "456" },
                new Review { Value1 = "789" },
            };
            var products = new List<Product>()
            {
                new Product { Value2 = DateTime.Now },
                new Product { Value2 = DateTime.Now.Subtract(TimeSpan.FromSeconds(5)) },
                new Product { Value2 = DateTime.Now.Subtract(TimeSpan.FromSeconds(10)) },
            };
            var pages = new List<Page>()
            {
                new Page { Value3 = 123 },
                new Page { Value3 = 456 },
                new Page { Value3 = 789 },
            };
            var rows = reviews
                .Zip(products, (r, p) => new { Review = r, Product = p })
                .Zip(pages, (rp, page) => new { rp.Review, rp.Product, Page = page });
            foreach (var row in rows)
            {
                Console.WriteLine("{0} - {1} - {2}", row.Review.Value1, row.Product.Value2, row.Page.Value3);
            }
        }
    }
