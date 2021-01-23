    public class FooContext : DbContext
    {
        protected override OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FooConfiguration());
        }
    }
