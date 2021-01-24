    using InjectionHttpClientFactory;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
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
