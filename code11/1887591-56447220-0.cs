    // register the class that provides the method and its dependencies.
    services.AddSingleton<OrderValidator>();
    services.AddSingleton<ISomeDependency, SomeDependency>();
    // register the delegate using a factory method that resolves 
    // the type that provides the method and then returns the method.
    services.AddSingleton<ValidateAddressFunction>(serviceProvider =>
    {
        var validator = serviceProvider.GetRequiredService<OrderValidator>();
        return validator.ValidateAddress;
    });
