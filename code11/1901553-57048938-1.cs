    class Startup : FunctionsStartup {
    
        public override void Configure(IFunctionsHostBuilder builder) {
            builder.Services.AddScoped<AzureFunctionClass>();
            builder.Services.AddScoped<ISomeClass, SomeClass>();
            //...
         }
    }
