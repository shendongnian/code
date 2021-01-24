    [assembly: WebJobsStartup(typeof(MyNamespace.MyStartup))]
    namespace MyNamespace
    {
        public static class Function1
        {
            [FunctionName("Function1")]
            public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,ILogger log)
            {
                log.LogInformation("C# HTTP trigger function processed a request.");
                return (ActionResult)new OkObjectResult($"Hello");
            }
        }
        public void Configure(IWebJobsBuilder builder)
        {
            builder.Services...
        }
    }
