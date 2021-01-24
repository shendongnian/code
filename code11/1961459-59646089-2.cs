    var host = Host.CreateDefaultBuilder(args)
        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureContainer<ContainerBuilder>(builder => {
            builder.RegisterType<MyDependencyType>();
            //...
        })
        .ConfigureServices(services => {
            services.AddHostedService<Worker>();
            //...
        })
        .Build();
    host.Run();
