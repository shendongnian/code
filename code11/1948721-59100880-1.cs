    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<CookiePolicyOptions>(options =>
        {
            // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy = SameSiteMode.None;
        });
        services.AddIdentity<IdentityUser, IdentityRole>(cfg =>
        {
            cfg.User.RequireUniqueEmail = false;//optional
            cfg.SignIn.RequireConfirmedEmail = false;//optional
        })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<YourDbContext>()
        .AddDefaultTokenProviders();
        services.AddDbContext<YourDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("YourConnectionstring")));
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    }
