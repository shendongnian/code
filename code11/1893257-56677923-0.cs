    public class MyDbContext : DbContext
        {
            public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
            {
                Database.EnsureCreated();
            }
    
            public DbSet<Values> Values { get; set; }
        }
