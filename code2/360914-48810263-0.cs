    public class BContext : DbContext
    {
        public BContext(DbContextOptions<BContext> options) : base(options)
        {
        }
        public DbSet<PriorityOverride> PriorityOverrides { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("My.Schema");
            builder.ApplyConfiguration(new OverrideConfiguration());
        }
    }
