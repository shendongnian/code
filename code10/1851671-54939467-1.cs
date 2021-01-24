     public class MVCDbContext:DbContext
    {
        public MVCDbContext(DbContextOptions<MVCDbContext> options) : base(options)
        { }
        public DbSet<Accommodations> Accommodations { get; set; }
        public DbSet<Location> Location { get; set; }
    }
