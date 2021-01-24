      public class Student
       {
           public int ID { get; set; }
           public Uri Homepage { get; set; }
       }
       Student s= new Student();
       string myUri = s.Homepage.AbsolutePath;
    or
    
        public class SchoolDbContext : DbContext {
        public DbSet<Student> Students { get; set; }
        
              protected override void OnModelCreating(ModelBuilder modelBuilder) {
                modelBuilder.Entity<Student>()
                .Property(t => t.Homepage.AbsolutePath);
              }
            }
