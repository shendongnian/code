        public static partial class Function1
    {
        [FunctionName("Sample1")]
        public static async Task<IActionResult> Sample1(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
