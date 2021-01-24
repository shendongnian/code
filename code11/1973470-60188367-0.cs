    public void ConfigureServices(IServiceCollection services) {
        services.AddRazorPages();
        services.AddServerSideBlazor();
    
        S3SvcConfiguration config = Configuration.GetSection("S3SvcConfiguration").Get<S3SvcConfiguration>();
        string region = Configuration.GetValue<string>("S3SvcConfiguration:RegionPoint");
        config.RegionPoint = RegionEndpoint.GetBySystemName(region);
        services.AddSingleton<IS3SvcConfiguration>(config);
    
        services.AddScoped <IS3FileSvc,S3FileSvc> ();
    }
