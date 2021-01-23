    public class FakeProductsRepository 
    {
        private readonly List<Product> fakeProducts = new List<Product>
        {
            new Product { ProductID = "xxx", Description = "xxx", Price = 1000 },
            new Product { ProductID = "yyy", Description = "xxx", Price = 2000 },
            new Product { ProductID = "zzz", Description = "xxx", Price = 3000 },
        };
        public void AddProduct(string productID, string description, int price)
        {
            fakeProducts.Add(new Product
            {
                ProductID = productID,
                Description = description,
                Price = price,
            });
        }
    
        public IQueryable<Product> Products
        {
            get { return fakeProducts.AsQueryable(); }
        }
    }
