    public class IdentityContext : IdentityDbContext<User>
    {
      public IdentityContext(DbContextOptions<IdentityContext> options)
          : base(options) { }
      protected override void OnModelCreating(ModelBuilder builder)
      {
        base.OnModelCreating(builder);
      }
    }
