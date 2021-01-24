    public void ConfigureServices(IServiceCollection services) {
        services.Configure<CookiePolicyOptions>(options => {
            // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy = SameSiteMode.None;
        });
        //bind object model
        ConnectionStrings connections = Configuration.Get<ConnectionStrings>();
        //add it to the service collection so that is accessible for injection
        services.AddSingleton(ConnectionStrings);
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    }
