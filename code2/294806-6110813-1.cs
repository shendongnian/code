    Func<IUnityContainer,object> createChain = container =>
        new LoggingProductRepository(
            new CachingProductRepository(
                container.Resolve<ProductRepository>(), 
                container.Resolve<ICacheProvider>()), 
            container.Resolve<ILogger>());
            
    c.RegisterType<IProductRepository>(new InjectionFactory(createChain));
    Assert.IsInstanceOf<LoggingProductRepository>(c.Resolve<IProductRepository>());
