    public class WeatherForecastController_Tests : IClassFixture<TestServerFixture>
    {
        public TestServerFixture TestServerFixture { get; private set; }
        public HttpClient Client { get; private set; }
        public ITestOutputHelper Output { get { return TestServerFixture.Output; } }
        public WeatherForecastController_Tests(TestServerFixture testServerFixture, ITestOutputHelper output)
        {
            TestServerFixture = testServerFixture.SetOutPut(output);
            Client = testServerFixture.CreateClient();
        }
        [...]
    }
    
