    public void ConfigureServices(IServiceCollection services)
    {
        ...
        services.AddMvc().ConfigureApplicationPartManager(m => 
      m.FeatureProviders.Add(new ControllerPluginProvider()));
    }
