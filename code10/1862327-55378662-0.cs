    using Microsoft.Azure.WebJobs.Hosting;
     [assembly: WebJobsStartup(typeof(Startup))]
       namespace Test.Functions
    {
    using System;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", true, true)
                .AddEnvironmentVariables()
                .AddDependencyInjection(ConfigureServices)
                .Build();
        }
      private void ConfigureServices(IServiceCollection services)
      {
        services.AddSingleton<ITestService>(s => new TestService("test string"));
      }
    }
