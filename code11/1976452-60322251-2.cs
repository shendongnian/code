        public class ApplicationDbContext : DbContext
    {
                public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
