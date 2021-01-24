    public void Configuration(IAppBuilder app)
    {    
        var services = new ServiceCollection();
        ConfigureServices(services);
        var resolver = new DefaultDependencyResolver(services.BuildServiceProvider());
        HttpConfiguration config = new HttpConfiguration();
        config.DependencyResolver = resolver;
        app.UseWebApi(config);
    }
