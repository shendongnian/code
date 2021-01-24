    public class UserStoreDbContext : DbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<UserProfile> Profiles { get; set; }
    
        public UserStoreDbContext(DbContextOptions<UserStoreDbContext> options) : base(options) { }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
    
            modelBuilder.Entity<User>(builder =>
                {
                    builder.HasDiscriminator<UserRoles>(x => x.Role)
                           .HasValue<User>(Roles.User)
                           .HasValue<Logistian>(Roles.ConcreteUser1)
                           .HasValue<Driver>(Roles.ConcreteUser2)
                });
    
                modelBuilder.Entity<UserProfile>(builder =>
                {
                    builder.HasDiscriminator<ProfileRoles>(x => x.Role)
                           .HasValue<UserProfile>(ProfileRoles.BaseProfile)
                           .HasValue<ConcreteUser1Profile>(Roles.ConcreteProfile1)
                           .HasValue<ConcreteUser2Profile>(Roles.ConcreteProfile2)
                });
        }
    }
