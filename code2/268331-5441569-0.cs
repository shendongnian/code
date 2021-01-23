    public class Category
    {
        public int CategoryId1 { get; set; }
        public int CategoryId2 { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int CategoryId1 { get; set; }
        public int CategoryId2 { get; set; }
        public virtual Category Category { get; set; }
    }
 
    public class Context : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>()
                .HasKey(c => new {c.CategoryId1, c.CategoryId2});
            modelBuilder.Entity<Product>()
                .HasRequired(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => new {p.CategoryId1, p.CategoryId2});
        }
    }
