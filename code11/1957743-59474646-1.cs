    public class Startup : FunctionsStartup {
        public override void Configure(IFunctionsHostBuilder builder) =>
            builder.Services
                .AddHttpClient()
                .AddCosmosDbServiceAsync();
    }
