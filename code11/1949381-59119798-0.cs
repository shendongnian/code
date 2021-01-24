 var config = new AppSecrets();
            Configuration.Bind("MyBudgetDB", config);
            services.AddSingleton(config);
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    $"{config.Database};User ID={config.User};Password={config.Password};{config.Options};"));
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {   }
        public DbSet<UserBudget> Budgets { get; set; }
    }
I'm now able to test that my data it's being persisted using Sqlite server (preferred for me because of the Object Relational Mapping feature).
