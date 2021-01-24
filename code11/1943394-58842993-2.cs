    public class Context: DbContext
    {
        public Context(DbContextOptions<MenuContext> options)
            : base(options)
        { }
    
        public DbSet<MenuCategory> MenuCategories{ get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
    }
