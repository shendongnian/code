    class MyContext : DbContext
    {
        public MyContext () : base()
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
