    public void ConfigureServices(IServiceCollection services)
    {
        IConfigurationSection dbsSection = Configuration.GetSection("Databases");
        services.Configure<DatabaseCatalog>(dbSection);
    }
