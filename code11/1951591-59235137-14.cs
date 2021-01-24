    public class MyTest : IClassFixture<TestServerFixture> {
        private readonly TestServerFixture fixture;
        public MyTest(TestServerFixture fixture) {
            this.fixture = fixture;
        }
        [Theory]
        [InlineData("settings1.json")]
        [InlineData("settings2.json")]
        public async Task Should_Execute_Using_Configurations(string settings) {
            var client = fixture.CreateClient(settings);
            
            //...use client
            
        }
    }
