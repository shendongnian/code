        public class ApplicationDbContext : KeyApiAuthorizationDbContext<AppUser, AppRole, 
        int>
        {
            public ApplicationDbContext(
                DbContextOptions options,
                IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, 
                operationalStoreOptions)
            {
            }
            public DbSet<Organization> Organizations { get; set; }
        }
