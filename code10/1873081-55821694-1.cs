    public class DbContext : IdentityDbContext<ApplicationUser>
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<ModeratedUser> ModeratedUsers { get; set; }
        public DbSet<ModeratorUser> ModeratorUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("UDC");
            builder.ApplyConfiguration<ModeratedUser>(new ModeratedUser());
            builder.ApplyConfiguration<ModeratedUser>(new ModeratorsConfiguration());
            builder.ApplyConfiguration<ModeratorModerated>(new ModeratorModeratedConfiguration());
            base.OnModelCreating(builder);
        }
    }
