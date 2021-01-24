    var configuration = new ConfigurationBuilder()
        .AddJsonFile("secret.json")
        .Build();
    //"ConfigurationBinder.Gett<T>" method comes from
    // Microsoft.Extensions.Configuration.Binder.dll
    ServiceBusTransportOptions options = configuration.GetSection("ServiceBus").Get<ServiceBusTransportOptions>();
    services.AddSingleton(options);
