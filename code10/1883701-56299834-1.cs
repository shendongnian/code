    public class MyFunction
    {
        private IDocumentClient _client;
        public MyFunction(IDocumentClient client)
        {
            _client = client;
        }
       
        [FunctionName("MyFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            // use _client here.
        }
    }
