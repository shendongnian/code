    public class Context : DbContext
    {		
      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
        modelBuilder.Entity<TYPE>().Ignore(c => c.PROPERTY);
      }
    }
