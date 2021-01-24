    private IServiceProvider GetServiceProvider()
    {
        var serviceCollection = new ServiceCollection();
        var builder = new ContainerBuilder();
        builder.Populate(serviceCollection);
        builder.RegisterType<SharedService>().As<ISharedService>().Named<ISharedService>("ForServiceA")
            .SingleInstance();
        builder.RegisterType<SharedService>().As<ISharedService>().Named<ISharedService>("ForServiceB")
            .SingleInstance();
        builder.Register(ctx => new ServiceA(ctx.ResolveNamed<ISharedService>("ForServiceA")))
            .As<IServiceA>();
        builder.Register(ctx => new ServiceB(ctx.ResolveNamed<ISharedService>("ForServiceB")))
            .As<IServiceB>();
        var container = builder.Build();
        return new AutofacServiceProvider(container);
    }
