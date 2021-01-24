    public class ApplicationContext : IdentityDbContext<UserApp, IdentityRole, string>
    {
        public ApplicationContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }
    }
