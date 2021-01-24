       class SchoolDbContext : DbContext
    {
         public SchoolDbContext() : DbContext
         {
             // default constructor
         }
         public SchoolDbContext(DbConnection connection) : DbContext(dbConnection, false)
         {
             // constructor that uses the in-memory database
         }
         public DbSet<School> Schools {get; set;}
         public DbSet<Student> Students {get; set;}
         ...
    }
