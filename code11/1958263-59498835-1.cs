    internal class MintPlayerContext : IdentityDbContext<User, Role, int>
    {
        // dotnet ef migrations add AddIdentity --project ..\MyProject.Data
        // dotnet ef database update --project ..\MyProject.Data
        // (only looks at your appsettings.json file, not your appsettings.*.json, so for local development)
        // To generate production migrations
        // dotnet ef migrations script --idempotent --output "MigrationScripts\AddIdentity.sql" --context MyDbContext --project ..\MyProject.Data
        private readonly IConfiguration configuration;
        public MintPlayerContext(IConfiguration configuration) : base()
        {
            this.configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyProject"), options => options.MigrationsAssembly("MyProject.Data"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUserLogin<int>>()
                .Property(ut => ut.LoginProvider)
                .HasMaxLength(50);
            modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUserLogin<int>>()
                .Property(ut => ut.ProviderKey)
                .HasMaxLength(200);
            modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUserToken<int>>()
                .Property(ut => ut.LoginProvider)
                .HasMaxLength(50);
            modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUserToken<int>>()
                .Property(ut => ut.Name)
                .HasMaxLength(50);
        }
    }
