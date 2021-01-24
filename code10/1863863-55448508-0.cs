     public class ProductParameter 
    {
        public int Id { get; set; }
    
        public virtual Product Product { get; set; } // No ProductId/ParameterId
        public virtual Parameter Parameter { get; set; }
    
        public string Value { get; set; }
    }
    modelBuilder.Entity<Product>()
        .HasMany(x => x.ProductParameters)
        .WithOne(x => x.Product)
        .HasForeignKey("ProductId"); // Sets up a shadow property.
