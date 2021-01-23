    public class MyContext : DbContext
    {
        public DbSet<AClass> AClasses { get; set; }
        public DbSet<BClass> BClasses { get; set; }
    }
