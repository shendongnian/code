    class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> productTable = new List<Product> {
                new Product { ProductId = 123, Name = "Cheese" },
                new Product { ProductId = 456, Name = "Milk" },
            };
            var r1 = productTable.FirstOrDefault(p => p.ProductId == 123);
            var r2 = productTable.Where(p => p.ProductId == 123).FirstOrDefault();
            // these print out the same thing
            Console.WriteLine(r1.Name);
            Console.WriteLine(r2.Name);
            Console.ReadLine();
        }
    }
