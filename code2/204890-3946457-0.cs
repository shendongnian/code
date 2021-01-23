    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IList<Product> ProductsOwned { get; set; }
    }
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IList<Customer> Owners { get; set; }
    }
