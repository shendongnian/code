    public class ManagementStudioDbContext: IdentityDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("MyCustomSchema");
        }
    }
