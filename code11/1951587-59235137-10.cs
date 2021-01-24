    public class TestServerFixture {
        static readonly Dictionary<string, TestServer> cache = 
            new Dictionary<string, TestServer>();
        public TestServerFixture() {
            //...
        }
        public HttpClient GetClient(string settings) {
            TestServer server = null;
            if(!cache.TryGetValue(settings, out server)) {
                var startup = new TestStartup(settings); //<---
                var builder = new WebHostBuilder()
                    .ConfigureServices(services => {
                        services.AddSingleton<IStartup>(startup);
                    });
                server = new TestServer(builder);
            }
            return server.CreateClient();
        }
    }
    
