    public class ManagementStudioDbContext: IdentityDbContext
    {
        public DbSet<ApplicationUsers> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .ToTable("ApplicationUsers", schema: "ManagementStudio");
        }
    }
