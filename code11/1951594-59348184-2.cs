TestStartup.cs
    public abstract class TestStartup : IStartup
    {
        public abstract IServiceProvider ConfigureServices(IServiceCollection services);
    
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
    
            // Code to configure test Startup
        }
    }
TestServerFixture.cs
    public abstract class TestServerFixture
    {
    
        protected TestServerFixture(IStartup startup)
        {
            var builder = new WebHostBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<IStartup>(startup);
            });
    
            var server = new TestServer(builder);
            Client = server.CreateClient();
        }
    
        public HttpClient Client { get; private set; }
    }
MyTest.cs
    public abstract class MyTest
    {
        private readonly TestServerFixture _fixture;
    
        protected MyTest(TestServerFixture fixture)
        {
            _fixture = fixture;
        }
    
        [Fact]
        public void ItShouldExecuteTwice_AgainstTwoSeparateConfigurations()
        {
            //...
        }
    }
