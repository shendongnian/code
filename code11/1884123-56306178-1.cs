    public static void ConfigureDependencyInjection()
    {
        var builder = new ContainerBuilder();
        // ...or you can register individual controlllers manually.
        builder.RegisterType<NumbersController>().InstancePerRequest();
        builder.RegisterType<NumbersBusinessLayer>().As<INumbersBusinessLayer>();
        IContainer container = builder.Build();
        DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
    }
