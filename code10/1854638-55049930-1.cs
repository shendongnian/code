    public class Functions
    {
        private HttpClient _httpClient;
        private IAppSettings _appSettings;
        private ILogger _log;
    
        public Functions(HttpClient httpClient, IAppSettings appSettings, ILoggerFactory loggerFactory)
        {
            _log = loggerFactory.CreateLogger<Functions>();
        }
  
        [FunctionName("Token")]
        public async Task<IActionResult> Token(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Token")]
            HttpRequest httpRequest)
        {
               // No need to keep getting the ILogger from the Run method anymore :)
        }
    }
