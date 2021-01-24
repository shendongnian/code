    using AzureFunctions.Extensions.Swashbuckle;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Hosting;
    using System.Reflection;
    using MyFunctionApp;
    [assembly: WebJobsStartup(typeof(WebJobsStartup))]
    namespace MyFunctionApp
    {
        public class WebJobsStartup : IWebJobsStartup
        {
            public void Configure(IWebJobsBuilder builder)
            {
                builder.AddSwashBuckle(Assembly.GetExecutingAssembly());
            }
        }
    }
