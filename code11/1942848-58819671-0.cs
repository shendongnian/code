    var builder = new ContainerBuilder();
    
    builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
    
    IServiceCollection services = new ServiceCollection();
    // The Microsoft.Extensions.Logging package provides this one-liner
    // to add logging services.
    services.AddLogging();
    
    // Once you've registered everything in the ServiceCollection, call
    // Populate to bring those registrations into Autofac. This is
    // just like a foreach over the list of things in the collection
    // to add them to Autofac.
    builder.Populate(services);
    
    IContainer container = builder.Build();
    
    httpConfig.DependencyResolver = new AutofacWebApiDependencyResolver(container);
