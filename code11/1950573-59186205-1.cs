    public class WeatherForecastController_Tests : IClassFixture<TestServerFixture> {
        public WeatherForecastController_Tests(TestServerFixture testServerFixture, ITestOutputHelper output) {
            Output = output;
            testServerFixture.Output = Output;
            Client = testServerFixture.Client;            
        }
        //...
