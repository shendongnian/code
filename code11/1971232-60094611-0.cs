    public DbSet<ProductCategory> ProductCategories { get; set; }
-----
    public class ProductCategory
    {
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
    }
