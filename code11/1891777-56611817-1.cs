    public class Product : List<ProductOption>
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public List<ProductOption> ProductOptions => this;
        public Product(string name, float price, params ProductOption[] productOption)
        {
            Name = name;
            Price = price;
            foreach (ProductOption p in productOption)
            {
                ProductOptions.Add(p);
            }
        }
    }
