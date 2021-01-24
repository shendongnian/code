    [assembly: WebJobsStartup(typeof(Startup))]
    
    namespace InjectionHttpClientFactory
    {
        public sealed class Startup : IWebJobsStartup
        {
            public void Configure(IWebJobsBuilder webJobsBuilder)
            {
                webJobsBuilder.Services.AddLogging();
            }
        }
    }
