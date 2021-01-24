    public class EntityContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            options.UseSqlServer(connectionString);
        }
        .....
    }
