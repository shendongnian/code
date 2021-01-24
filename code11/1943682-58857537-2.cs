    public class CustomerControllerTest : IClassFixture<CustomWebApplicationFactory<IntegrationStartup>>
        {
            private readonly HttpClient _client;
            private readonly CustomWebApplicationFactory<IntegrationStartup> _factory;
            private readonly CustomerControllerInitialization _customerControllerInitialization;
            public CustomerControllerTest(CustomWebApplicationFactory<IntegrationStartup> factory)
            {
                _factory = factory;
                _client = _factory.CreateClient();
            }
    }
