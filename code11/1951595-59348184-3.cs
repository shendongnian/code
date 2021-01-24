TestStartup.cs
    public class TestStartup : Common.IntegrationTests.TestStartup
    {
        public override IServiceProvider ConfigureServices(IServiceCollection services)
        {
           var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", false) // appsettings for Setting1
               .AddEnvironmentVariables()
               .Build();
    
            services.AddMvc()
                .SetCompatibilityVersion(version: CompatibilityVersion.Version_2_2);
    
            // Code to add required services based on configuration
    
    
            return services.BuildServiceProvider();
        }
    }
TestServerFixture.cs
    public class TestServerFixture : Fixtures.TestServerFixture
    {
        public TestServerFixture() : base(new TestStartup())
        {
        }
    }
MyTests.cs
    public class MyTests : Common.IntegrationTests.MyTests, IClassFixture<TestServerFixture>
    {
        public MyTests(TestServerFixture fixture) : base(fixture)
        {
        }
    }
