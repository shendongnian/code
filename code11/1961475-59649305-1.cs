    class MyDbContext : DbContext
    {
        public DbSet<Student> Students {get; set;}
        public DbSet<Language> Languages {get; set;}
    }
