csharp
public static IWebHostBuilder ConfigureFanciness(this IWebHostBuilder hostBuilder)
{
    return hostBuilder.ConfigureServices(delegate (WebHostBuilderContext context, IServiceCollection services)
    {
        var fancinessConfiguration = context.Configuration.GetSection("Fanciness");
        services.Configure<FancinessSettings>(fancinessConfiguration);
        services.AddSingleton<IFancyService, FancyService>(sp =>{
            var fancy=ActivatorUtilities.CreateInstance(sp,typeof(FancyService)) as FancyService;
            fancy.Initialize();      
            return fancy;
        });
    });
}
The same trick could also be used to register a logger provider. Since an `ILogger<>` service depends on `IEnumberable<ILoggerProvider>`, we could register an `ILoggerProvider` instance that provides an additional `INullLogger` in order to configure the logging behavior according to the current `IFancyService` :
c#
private static void ConfigureApplicationLogging(WebHostBuilderContext context, ILoggingBuilder loggingBuilder)
{
    var loggingConfiguration = context.Configuration.GetSection("Logging");
    var descriptor=ServiceDescriptor.Singleton<ILoggerProvider,NullLoggerProvider>(sp =>{
        var provider = NullLoggerProvider.Instance;
        var fancy = sp.GetRequiredService<IFancyService>();
        if(fancy.IsEnabled)      
        {
            loggingBuilder.AddDebug();
            loggingBuilder.AddEventLog(loggingConfiguration);
            loggingBuilder.AddEventSourceLogger(); 
            // ... add more configuration as you like
        }else{
            loggingBuilder.AddConsole();
        }
        return provider;
    });
    loggingBuilder.Services.TryAddEnumerable(descriptor);
    loggingBuilder.AddConfiguration(loggingConfiguration);
}
As a side note, be aware once the logger has been built, don't change the `IFancyService.IsEnabled`. That's because the `ILogger<>` service is a registered as a singleton and never changed once created.
