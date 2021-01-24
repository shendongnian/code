    public IServiceProvider ConfigureServices(IServiceCollection services) {
        var builder = new ContainerBuilder();
        builder.Populate(services);
        builder.RegisterType<EfGetBooksCommand>().As<IGetBooksCommand>();
        var container = builder.Build();
        return new AutofacServiceProvider(container);
    }
