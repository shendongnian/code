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
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Pad<T>(this IEnumerable<T> source,
            int desiredCount, T padWith = default(T))
        {
            int counter = 0;
            var enumerator = source.GetEnumerator();
            while(counter < desiredCount)
            {
                yield return enumerator.MoveNext()
                    ? enumerator.Current
                    : padWith;
                ++counter;
            }
        }
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
            };
            var pages = new List<Page>()
            {
                new Page { Value3 = 123 },
            };
            int maxCount = Math.Max(Math.Max(reviews.Count, products.Count), pages.Count);
            var rows = reviews.Pad(maxCount)
                .Zip(products.Pad(maxCount), (r, p) => new { Review = r, Product = p })
                .Zip(pages.Pad(maxCount), (rp, page) => new { rp.Review, rp.Product, Page = page });
            foreach (var row in rows)
            {
                Console.WriteLine("{0} - {1} - {2}"
                    , row.Review != null ? row.Review.Value1 : "(null)"
                    , row.Product != null ? row.Product.Value2.ToString() : "(null)"
                    , row.Page != null ? row.Page.Value3.ToString() : "(null)"
                    );
            }
        }
    }
