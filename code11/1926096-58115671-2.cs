    services.AddCors(m => m.AddPolicy("AllowAll", o => 
        o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
    services.Configure<Config>(Configuration.GetSection("ConnectionStrings"));
    services.Configure<Config>(Configuration.GetSection("Options"));
    services.Configure<CookiePolicyOptions>(options =>
    {
        // This lambda determines whether user consent for 
        // non-essential cookies is needed for a given request.
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
    });
    
    //register the individual interfaces, extracting the registered IOptions<Config>
    services.AddSingleton<IDataConfig>(sp => sp.GetRequiredService<IOptions<Config>>().Value);
    services.AddSingleton<IIdentityServerConfig>(sp => sp.GetRequiredService<IOptions<Config>>().Value);
    services.AddSingleton<IStorageConfig>(sp => sp.GetRequiredService<IOptions<Config>>().Value);
    
    //...omitted for brevity
    
