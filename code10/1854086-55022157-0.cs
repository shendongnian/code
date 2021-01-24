    [assembly: WebJobsStartup(typeof(Startup))]
    
    public sealed class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder webJobsBuilder)
        {
            // Registers the HttpClient as a singleton.
            webJobsBuilder.Services.AddSingleton(new HttpClient());
        }
    }
