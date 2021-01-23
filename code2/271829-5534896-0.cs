    public class MyContext : DbContext
    {
        ...
    
        protedte override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();   
        }
    }
