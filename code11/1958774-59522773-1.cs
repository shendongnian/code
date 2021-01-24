        public static partial class Function1
    {
        [FunctionName("Sample2")]
        public static async Task<IActionResult> Sample2(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        
