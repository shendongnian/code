    public class MyDbContext : DbContext
    {
      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
        modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(GetType())); //Current Assembly
        base.OnModelCreating(modelBuilder);
      }
    }
