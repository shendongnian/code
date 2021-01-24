    public class MyDbContext : DbContext
    {
       public MyDbContext(string connectionString) : base(connectionString) {}
       public DbSet<Record> Records {get; set;}
    }
