    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        var settings = Configuration.GetSection("DynamicsConnector");
        services.Configure<DynamicsConnectorOptions>(settings);
        services.AddScoped<IDynamicsConnector, DynamicsConnector>();
    }
