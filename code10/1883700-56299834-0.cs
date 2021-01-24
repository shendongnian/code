    using Microsoft.Azure.Functions.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection;
    [assembly: FunctionsStartup(typeof(MyApp.Startup))]
    namespace MyApp
    {
        public class Startup : FunctionsStartup
        {
            public override void Configure(IFunctionsHostBuilder builder)
            {
                IDocumentClient client = GetCustomClient();
                builder.Services.AddSingleton<IDocumentClient>(client);
            }
    }
