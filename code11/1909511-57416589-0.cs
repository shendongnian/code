    [TestMethod]
    public void TestCircularDependency()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IA, A>();
        services.AddSingleton<IB, B>();
        var provider = services.BuildServiceProvider();
        var a = provider.GetService<IA>();
        var b = provider.GetService<IB>();
    }
