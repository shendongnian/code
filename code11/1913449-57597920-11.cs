    [DataTestMethod]
    [DataRow("MessageTypeOne")]
    [DataRow("MessageTypeTwo")]
    public void FactoryResolvesMessageHandlers(string messageType)
    {
        var services = new ServiceCollection();
        services.AddMessageHandlers();
        var provider = services.BuildServiceProvider();
        var factory = provider.GetService<IMessageHandlerFactory>();
        var handler = factory.GetHandler(messageType);
        Assert.IsNotNull(handler);
    }
