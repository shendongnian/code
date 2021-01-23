    namespace PizzaSoftware.Data
    {
    public class PizzaSoftwareData : DbContext
    {
            public PizzaSoftwareData()
            : base("name=PizzaSoftwareData")
            {
            Database.SetInitializer<PizzaSoftwareData>(new CreateDatabaseIfNotExists<PizzaSoftwareData>());
            }
            public DbSet<Customer> Customers { get; set; }
            public DbSet<Order> Orders { get; set; }
            public DbSet<Product> Products { get; set; }
            public DbSet<User> Users { get; set; }
        }
    }
