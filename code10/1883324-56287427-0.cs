    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, ApplicationUserClaim, ApplicationUserRole, IdentityUserLogin<string>, ApplicationRoleClaim, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ApplicationUserEntityBuilder());
            builder.ApplyConfiguration(new ApplicationRoleEntityBuilder());
            builder.ApplyConfiguration(new ApplicationUserClaimEntityBuilder());
            builder.ApplyConfiguration(new ApplicationUserRoleEntityBuilder());
            builder.ApplyConfiguration(new ApplicationRoleClaimEntityBuilder());
        }
    }
 
