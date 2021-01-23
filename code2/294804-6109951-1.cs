    [Test]
    public void ResolveWithDecorators2()
    {
        UnityContainer c = new UnityContainer();
        c.RegisterInstance<IDatabaseConnection>(new Mock<IDatabaseConnection>().Object);
        c.RegisterInstance<ILogger>(new Mock<ILogger>().Object);
        c.RegisterInstance<ICacheProvider>(new Mock<ICacheProvider>().Object);
        c.RegisterDecoratorChain<IProductRepository>(new Type[] { typeof(ProductRepository), typeof(CachingProductRepository), typeof(LoggingProductRepository) });
        Assert.IsInstanceOf<LoggingProductRepository>(c.Resolve<IProductRepository>());
    }
