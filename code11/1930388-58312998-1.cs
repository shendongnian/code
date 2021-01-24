    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        // ...
        public virtual Product ParentProduct { get; set; }
        public virtual ICollection<Product> ChildProducts { get; set; } = new List<Product>();
    }
    
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
           HasKey(x => x.ProductId);
           HasOptional(x => x.ParentProduct)
              .WithMany(x => x.ChildProducts)
              .Map(x => x.MapKey("ParentProductId")); 
        }
    }
