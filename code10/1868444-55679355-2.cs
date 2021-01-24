    class MyDbContext : DbContext
    {
        public DbSet<MainGroup> MainGroups {get; set;}
        public DbSet<SubGroup> SubGroups {get; set;}
        public DbSet<Product> Products {get; set;}
    }
