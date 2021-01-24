    public class MyController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        public MyController(IWebHostEnvironment env)
        {
            this._environment = env;
        }
        private void InitSearch(IWebHostEnvironment env)
        {
            // Create a configuration using the appsettings file.
            _builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            _configuration = _builder.Build();
            // Pull the values from the appsettings.json file.
            string searchServiceName = _configuration["SearchServiceName"];
            string queryApiKey = _configuration["SearchServiceQueryApiKey"];
            // Create a service and index client.
            _serviceClient = new SearchServiceClient(searchServiceName, new SearchCredentials(queryApiKey));
            _indexClient = _serviceClient.Indexes.GetClient("example-index");
        }
    }
