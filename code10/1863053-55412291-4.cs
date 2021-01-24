    public class FrameworkContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
    public class ExtendedContext : FrameworkContext
    {
        public DbSet<Order> Orders { get; set; }
    }
