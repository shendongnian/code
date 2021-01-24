    [assembly: WebJobsStartup(typeof(Startup))]
    
    public sealed class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder webJobsBuilder)
        {
            webJobsBuilder.Services.AddHttpClient();
        }
    }
