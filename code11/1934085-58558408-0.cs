    public class MyDbContext : DbContext
    {
        public DbSet<MyEntity> Entities { get; set; }
        public MyDbContext (DbContextOptions<MyDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply configurations
        }
    }
