    [assembly: WebJobsStartup(typeof(Startup))]
    namespace MyApp
    {
        public class Startup : IWebJobsStartup
        {
            public void Configure(IWebJobsBuilder builder)
            {
                builder.Services.AddHttpClient();
                builder.Services.AddTransient<IAppSettings, AppSettings>();     
                builder.Services.AddLogging();
            }
    }
