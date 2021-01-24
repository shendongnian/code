    namespace AutoFacFunctionAppPrototype.Functions
    {
        public static class CounterFunction
        {
            [FunctionName("Counter")]
            public static IActionResult Run(
                [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req,
                [Inject]ITransientService transientService,
                [Inject]IScopedService scopedService,
                [Inject]ISingletonService singletonService,
                 ILogger logger)
            {
                logger.LogInformation("C# HTTP trigger function processed a request.");
    
                string result = String.Join(Environment.NewLine, new[] {
                    $"Transient: {transientService.GetCounter()}",
                    $"Scoped: {scopedService.GetCounter()}",
                    $"Singleton: {singletonService.GetCounter()}",
                });
                return new OkObjectResult(result);
            }
        }
    }
