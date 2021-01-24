    public static class YourNewFunctionClassName
    {
    [FunctionName("your new function name")]
    public static HttpResponseMessage Run(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
    {
    // your code here
    }
