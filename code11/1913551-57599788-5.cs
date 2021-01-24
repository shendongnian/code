    services.AddSingleton<IMessageHandlerFactory>(serviceProvider =>
    {
        var factory = new MessageHandlerFactory();
        factory.RegisterHandler("MessageOne",
            serviceProvider.GetService<MessageHandlerWrapper<MessageOne>>);
        factory.RegisterHandler("MessageTwo",
            serviceProvider.GetService<MessageHandlerWrapper<MessageTwo>>);
        return factory;
    });
