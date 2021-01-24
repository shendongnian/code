 
    public static class CuriousDevJsonSettingsFunction
        {
            [FunctionName("CuriousDevJsonSettingsFunction")]
            public static async Task<IActionResult> Run(
                [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
                ILogger log, ExecutionContext context)
            {
                log.LogInformation("C# HTTP trigger function processed a request.");
    
                //Configuration Settings
                  var config = new ConfigurationBuilder()
                 .SetBasePath(context.FunctionAppDirectory)
                 .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                 .AddEnvironmentVariables()
                 .Build();
    
                //Access local.settings.json file 
                var otherSettings = new OtherSettings();
                config.Bind("OtherSettings", otherSettings);
    
                return new OkObjectResult(otherSettings.MyData);
            }
        }
