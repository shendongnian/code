    public class SalesDBContext:DbContext
        {
            public DbSet<Order> Orders { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Testing;Integrated Security=True");
                base.OnConfiguring(optionsBuilder);
            }
        }
