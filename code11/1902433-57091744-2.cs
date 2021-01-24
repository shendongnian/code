    public class InMemoryHttpClientFactory: IHttpClientFactory
    {
        private readonly TestServer _server;
        public InMemoryHttpClientFactory(TestServer server)
        {
            _server = server;
        }
        public HttpClient CreateClient(string name)
        {
            return _server.CreateClient();
        }
    }
