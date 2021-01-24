    [assembly: FunctionsStartup(typeof(MyNamespace.Startup))]
    
    namespace MyNamespace
    {
        public class Startup : FunctionsStartup
        {
            public override void Configure(IFunctionsHostBuilder builder)
            {
                builder.Services.AddHttpClient();
                builder.Services.AddSingleton((s) => {
                    return new CosmosClient(Environment.GetEnvironmentVariable("COSMOSDB_CONNECTIONSTRING"));
                });
                builder.Services.AddSingleton<ILoggerProvider, MyLoggerProvider>();
            }
        }
    }
