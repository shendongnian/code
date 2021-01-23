    public class SchoolDBContext : DbContext
    {   
       public SchoolDBContext(): base("SchoolDBConnectionString")
       {
          //Disable initializer
          Database.SetInitializer<SchoolDBContext>(null);
       }
       public DbSet<Student> Students { get; set; }
       public DbSet<Standard> Standards { get; set; }
    }
  
  
