    public class TestServerFixture : WebApplicationFactory<TestStartup> {
        private Lazy<HttpClient> client = new Lazy<HttpClient>(() => return Server.CreateClient());
    
        private IHost _host;
        public HttpClient Client => client.Value;
        public ITestOutputHelper Output { get; set; }
    
        public TestServerFixture(){
            //...
        }
    
        //...all other code remains the same
    }
