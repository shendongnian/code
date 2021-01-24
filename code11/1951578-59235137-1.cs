    public class TestServerFixture {
        public TestServerFixture() {
            
        }
        public HttpClient GetClient(string settings) { 
            var startup = new TestStartup(settings); //<---
            var builder = new WebHostBuilder()
                .ConfigureServices(services => {
                    services.AddSingleton<IStartup>(startup);
                });
            var server = new TestServer(builder);
            return server.CreateClient();
        }
    }
    
