            public enum ProductName
            {
                Product1 = 2,
                Product2 = 3,
                Product3 = 4,
                Product4 = 1,
                None = 0
            }
            static void Main(string[] args)
            {
                Random rand = new Random();
                List<ProductName> products = Enumerable.Range(0,10).Select(x => (ProductName)rand.Next(0,5)).ToList();
                string[] names = products.Select(x => x.ToString()).ToArray();
            }
