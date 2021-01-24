        public static IServiceCollection ConfigureIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRoleValidator<Role>, MyRoleValidator>(); //this line...
            services.AddIdentity<ApplicationUser, Role>(options =>
            {
                options.Password.RequiredLength = configuration.GetSection(nameof(IdentitySettings)).Get<IdentitySettings>().PasswordRequiredLength;
                options.Password.RequireLowercase = configuration.GetSection(nameof(IdentitySettings)).Get<IdentitySettings>().PasswordRequireLowercase;
                options.Password.RequireUppercase = configuration.GetSection(nameof(IdentitySettings)).Get<IdentitySettings>().PasswordRequireUppercase;
                options.Password.RequireNonAlphanumeric = configuration.GetSection(nameof(IdentitySettings)).Get<IdentitySettings>().PasswordRequireNonAlphanumeric;
                options.Password.RequireDigit = configuration.GetSection(nameof(IdentitySettings)).Get<IdentitySettings>().PasswordRequireDigit;
            })
                .AddRoleValidator<MyRoleValidator>() //this line ...
                .AddEntityFrameworkStores<SepidIdentityContext>()
                .AddDefaultTokenProviders();
            return services;
        }
