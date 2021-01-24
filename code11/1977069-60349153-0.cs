    // Notice that the assembly definition comes before the namespace
    [assembly: FunctionsStartup(typeof(FunctionApp1.Startup))]
    namespace FunctionApp1
    {
        public class Startup : FunctionsStartup
        {
            public override void Configure(IFunctionsHostBuilder builder)
            {
                // You can of course change service lifetime as needed
                builder.Services.AddTransient<IInternalYoutubeService, InternalYoutubeService>();
            }
        }
    }
