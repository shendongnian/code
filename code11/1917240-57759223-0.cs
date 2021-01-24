            [FunctionName("CuriousDevJsonSettingsFunction")]
            public static async Task<IActionResult> Run(
                [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
                ILogger log, ExecutionContext context)
            {
                log.LogInformation("C# HTTP trigger function processed a request.");
            }
