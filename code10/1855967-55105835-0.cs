    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
       ...
       services.AddHttpClient();
       var containerBuilder = new ContainerBuilder();
       containerBuilder.Populate(services);
       var container = containerBuilder.Build();
       return new AutofacServiceProvider(container);
    }
