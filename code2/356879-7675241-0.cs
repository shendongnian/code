    public class Product
    {
        private Product(){}
        public string Name { get; private set; }
        public static Product Create(string name)
        {
            return new Product { Name = name };
        }
    }
