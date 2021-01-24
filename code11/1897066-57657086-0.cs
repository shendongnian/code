    public class RestClientFactory : IRestClientFactory
        {
            protected IHttpClientFactory HttpClientFactory { get; }
            protected IServiceProvider ServiceProvider { get; }
    
            public RestClientFactory(IHttpClientFactory httpClientFactory, IServiceProvider serviceProvider)
            {
                HttpClientFactory = httpClientFactory;
                ServiceProvider = serviceProvider;
            }
    
            public IRestClient Create()
            {
                return Create(ServiceProvider.GetService<IRestClientSettings>());
            }
    
            public IRestClient Create(IRestClientSettings settings)
            {
                return new RestClient(
                    settings,
                    HttpClientFactory.CreateClient()
                );
            }
        }
