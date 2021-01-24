Azure Functions Core Tools (2.7.1158 Commit hash: f2d2a2816e038165826c7409c6d10c0527e8955b)
Function Runtime Version: 2.0.12438.0
**Startup.cs**
> No need to add ```builder.Services.AddLogging();``` it's imported automatically in the container.
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
[assembly: FunctionsStartup(typeof(MyFunctionsNamespace.Startup))]
namespace MyFunctionsNamespace
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<IMyService, MyService>();
        }
    }
}
**MyFunkyFunction.cs**
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
namespace MyFunctionsNamespace
{
    public class MyFunkyFunction
    {
        private readonly IMyService _myService;
        public MyFunkyFunction(IMyService myService)
        {
            _myService = myService;
        }
        [FunctionName("FunkyFunc")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]
            HttpRequest req
            , ILogger log
        )
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            _myService.Do();
            return new OkObjectResult("Hello");
        }
    }
}
**IMyService.cs**
> Anything in ```LogCategories.CreateFunctionUserCategory``` will do the job. It seems to be some WebJob legacy requirement.
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Logging;
namespace MyFunctionsNamespace
{
    public interface IMyService
    {
        void Do();
    }
    public class MyService : IMyService
    {
        private readonly ILogger _log;
        public MyService(ILoggerFactory loggerFactory)
        {
            // Important: Call CreateFunctionUserCategory, otherwise log entries might be filtered out
            // I guess it comes from Microsoft.Azure.WebJobs.Logging
            _log = loggerFactory.CreateLogger(LogCategories.CreateFunctionUserCategory("Common"));
        }
        public void Do()
        {
            _log.Log(LogLevel.Information, "Hello from MyService");
        }
    }
}
