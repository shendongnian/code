     public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    }
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    }
    public class ProductCategory
    {
        [Key]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Key]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
