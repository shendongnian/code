    internal static ContainerBuilder ConfigureAutofac(this ContainerBuilder source)
    {
        source.RegisterApiControllers(typeof(OrderController).Assembly);
    
        source.Register(c => ScannenBijLadenContextMock.Create())
            .AsImplementedInterfaces()
            .InstancePerRequest();
    
        return source;
    }
