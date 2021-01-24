    services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));
    services.AddDefaultIdentity<IdentityUser>()
        .AddDefaultUI(UIFramework.Bootstrap4)
        .AddEntityFrameworkStores<ApplicationDbContext>();
            
    services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
    .AddAzureAD(options => Configuration.Bind("AzureAd", options));
    services.Configure<OpenIdConnectOptions>(AzureADDefaults.OpenIdScheme, options => {
        options.SignInScheme= IdentityConstants.ExternalScheme;
        
        //other config
    });
