        public class RestDataService: IRestDataService
        {
            private static HttpClient _client;
            private static AppConfiguration _configuration;
            private const short MaxRetryAttempts = 3;
            private const short TimeSpanToWait = 2;
            public RestDataService(AppConfiguration configuration
                , HttpClient client)
            {
                _client = configuration.HttpClient;
                _configuration = configuration;
            }
        }
