    public class EnterpriseDbContext : DbContext
    {
        public DbSet<EnterpriseUser> EnterpriseUsers { get; set; }
        // .. Your data entities.
    }
