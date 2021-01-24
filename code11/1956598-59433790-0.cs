    public class aspnetpakshavadContext: IdentityDbContext {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                optionsBuilder.UseSqlServer("your-connection-string"); // you will notice I removed .IsConfigured check - I believe this is redundant as OnConfiguring should always have it set to `false`
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(builder); // this is calling all relevant code from IdentityDbContext that you have previously copied. Yours will go afterwards to ensure your changes are applied last
            modelBuilder.ApplyConfiguration(new MyAspNetUserConfiguration());// your extension point to modify particular entity model     
        }
        public class MyAspNetUserConfiguration: IEntityTypeConfiguration<PortalUser>
        {
            public void Configure(EntityTypeBuilder<AspNetUser> builder)
            {
                builder.HasFilter("([NormalizedUserName] IS NOT NULL)"); // Builders are chained, so as long as you've called this after base method `OnModelCreating` above - this should add to existing model.
            }
        }
    }
