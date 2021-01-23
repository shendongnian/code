    public class MyContext : DbContext
    {
        public DbSet<BClass> BClasses { get; set; }
        public DbSet<AClass> AClasses { get; set; }
    }
