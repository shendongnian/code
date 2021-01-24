    public class SlackLoggerProvider : ILoggerProvider {
        private readonly IHttpClientFactory clientFactory;
    
        public SlackLoggerProvider(IHttpClientFactory clientFactory) {
            this.clientFactory = clientFactory;
        }
    
        //...
    }
