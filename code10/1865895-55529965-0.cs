    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
      
        public DbSet<Product> Product { get; set; }       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var property in typeof(Product).GetProperties())
            {
                builder.Entity<Products_Abstract>()
                       .Property(property.PropertyType, property.Name);
            }
        }
    }
