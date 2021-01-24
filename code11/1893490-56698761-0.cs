        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));
        services.AddDefaultIdentity<IdentityUser>()
            .AddDefaultUI(UIFramework.Bootstrap4)
            .AddEntityFrameworkStores<ApplicationDbContext>();
        services.AddAuthentication().AddLinkedIn(options =>
        {
            options.ClientId = Configuration["Authentication:LinkedIn:ClientId"];
            options.ClientSecret = Configuration["Authentication:LinkedIn:ClientSecret"];
        });
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
