    public class MyIntegrationTests : IDisposable
        {
            private readonly IWebHost _webApp;
            private const string Url = "http://localhost:1234";
    
            public MyIntegrationTests ()
            {
                _webApp = new WebHostBuilder()
                    .UseKestrel()
                    .UseStartup<Startup>()
                    .UseUrls(Url)
                    .Build();
    
                _webApp.Start();
            }
