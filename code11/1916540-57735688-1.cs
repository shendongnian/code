      public class SchoolContext: DbContext 
      {
        public SchoolContext(): base("SchoolDB") 
        {
           Database.SetInitializer(new SchoolDBInitializer());
        }
    
        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Standards { get; set; }
      }
