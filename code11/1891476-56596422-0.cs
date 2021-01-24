    private void RegisterAutofac()
    {
        var builder = new Autofac.ContainerBuilder();
        builder.RegisterControllers(Assembly.GetExecutingAssembly());
        builder.RegisterSource(new ViewRegistrationSource());
    
        // The object to be injected in constructor etc.
        builder.RegisterType<MyImpl>().As<IMyInterface>();
        var container = builder.Build();
        DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
    }
