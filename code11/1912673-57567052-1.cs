        services.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
        services.ConfigureApplicationCookie(options =>
        {
            options.EventsType = typeof(CustomCookieAuthenticationEvents);
        });
        services.AddScoped<CustomCookieAuthenticationEvents>();
