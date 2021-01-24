    //
    /// <summary>
    /// Startup Extensions
    /// </summary>
    public static class StartupExtensions
    {
        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>(
                options => {
                    options.Stores.MaxLengthForKeys = 128;
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 8;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddUserManager<UserManager<ApplicationUser>>()
                .AddRoleManager<RoleManager<ApplicationRole>>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddDefaultTokenProviders();
            return services;
        }
    }
