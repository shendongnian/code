    class Program
        {
            public static void Main(string[] args)
            {
                var list = GetProducts(new List<string> { "a", "b" });
                foreach (var val in list)
                {
                    Console.WriteLine("Result:" + val);
                }
    
            }
    
            public static IEnumerable<string> GetProducts(List<string> filter)
            {
                List<Product> proc = new List<Product>();
    
                IQueryable<Product> query = new List<Product>
                {
                    new Product
                    {
                        tMal = "a,b",
                    },
                    new Product
                    {
                        tMal = "a",
                    },
                    new Product
                    {
                        tMal = "b",
                    }
                }.AsQueryable();
    
                foreach (var item in filter)
                {
                    query = query.Where(x => x.tMal.Contains(item));
                }
    
                proc.AddRange(query.ToList());
                return proc.Select(s => s.tMal);
            }
        }
    
        internal class Product
        {
            public string tMal;
        }
