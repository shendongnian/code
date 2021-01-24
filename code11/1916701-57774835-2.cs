    public class TestServerFixture : IDisposable
    {
        public TestServer Server { get; }
        public HttpClient Client { get; }
        public T GetService<T>() => (T)Server.Host.Services.GetService(typeof(T));
        public TestServerFixture(ITestOutputHelper output)
        {
            var builder = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseEnvironment("Development")
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                          .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                          .AddEnvironmentVariables();
                })
                .UseStartup<TestStartup>()
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddXunit(output);
                });
            Server = new TestServer(builder);
            Client = Server.CreateClient();
        }
        public void Dispose()
        {
            Server.Dispose();
            Client.Dispose();
        }
    }
