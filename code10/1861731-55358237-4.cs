    public class BlogContext : IdentityDbContext<ApplicationUser>
        {
            public BlogContext(DbContextOptions<DbContext> options) : base()
            {
    
            }
    
            public DbSet<Message> Messages { get; set; }
            public DbSet<Timeline> Timelines { get; set; }
            public DbSet<ApplicationUser> applicationUsers { get; set; }
            public DbSet<IdentityUserClaim<Guid>> IdentityUserClaims { get; set; }
            public DbSet<IdentityUserClaim<string>> IdentityUserClaim
            {
                get;
                set;
            }
                        
        }
