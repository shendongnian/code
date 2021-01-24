public IntegrationService(
            TimeSpan cachePeriod,
            ILogger<StatusService> logger,
            IHttpClientFactory clientFactory)
You can in your Startup.cs add it to your HostedService like this :
services.AddHostedService 
    (serviceProvider => 
        new StatusService(
            TimeSpan.FromDays(1), 
            serviceProvider.GetService<ILogger<StatusService>>(), 
            serviceProvider.GetService<IHttpClientFactory>()));
