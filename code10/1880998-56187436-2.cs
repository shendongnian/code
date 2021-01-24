     public class Context : DbContext
        {
            public Context(DbContextOptions< Context > options) : base(options)
            {
    
            }
            public Context()
            {
    
            }
            public DbSet<Foo> Foos { get; set; }
    
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.ApplyConfiguration(new FooMapping());
                base.OnModelCreating(modelBuilder);
            }
        }
