    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    }
