    public class TestServerFixture : WebApplicationFactory<TestStartup>
    {
        public HttpClient Client { get; }
        public ITestOutputHelper Output { get; set; }
        protected override IHostBuilder CreateHostBuilder()
        {
            var builder = Host.CreateDefaultBuilder()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders(); //All API logging providers are cleared
                    logging.AddXunit(Output); //Internal extension which redirect all log to the ITestOutputHelper 
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseStartup<TestStartup>()
                        .ConfigureTestServices((services) =>
                        {
                            //Without that, the client always returns 404
                            //(even if it has already been set in Startup.Configure)
                            services
                                .AddControllers()
                                .AddApplicationPart(typeof(Startup).Assembly);
                        });
                });
            return builder;
        }
        //ITestOutputHelper is set in the constructor of the Test class
        public TestServerFixture SetOutPut(ITestOutputHelper output)
        {
            Output = output;
            return this;
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            Output = null;
        }
    }
