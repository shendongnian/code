    public class ApplicationDbContext
    : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>,
    ApplicationUserRole, IdentityUserLogin<string>,
    IdentityRoleClaim<string>, IdentityUserToken<string>>
    {        
        private readonly IHttpContextAccessor _contextAccessor;
        private Guid _tenantId;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor contextAccessor, ITenantProvider _tenantProvider)
            : base(options)
        {
            _contextAccessor = contextAccessor;
            _tenantId = _tenantProvider.GetTenantId();
      
        }
    
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Tenant> Tenant { get; set; }
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
    
            builder.Entity<Tenant>().HasQueryFilter(e => e.TenantId == _tenantId);
            builder.Entity<ApplicationUser>().HasQueryFilter(e => e.TenantId == _tenantId);            
        }       
    }
