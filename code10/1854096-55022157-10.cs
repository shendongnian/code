    [assembly: FunctionsStartup(typeof(Startup))]
        
    public sealed class Startup : FunctionsStartup
    {
        public void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();
        }
    }
