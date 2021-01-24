    //...
    
    IServiceCollection serviceCollection = new ServiceCollection();
    //...Add SDK
    serviceCollection.AddMySDK();
    //Add my services.
    serviceCollection.AddScoped<IConsumer, Consumer>()
    //...
