    [assembly: WebJobsStartup(typeof(Startup))]
    namespace MyApp
    {
        public class Startup : IWebJobsStartup
        {
            public void Configure(IWebJobsBuilder builder)
            {
                //other code
       
                builder.Services.AddLogging();
            }
    }
    
    
    
    public class Functions
    {
        //other code
        private ILogger _log;
    
        public Functions(ILoggerFactory loggerFactory)
        {
            _log = loggerFactory.CreateLogger<Functions>();
        }
    
        [FunctionName("Token")]
        public async Task<IActionResult> Function1(
            [HttpTrigger()]...)
        {
               _log.LogInformation("Function1 invoked");
        }
    }
