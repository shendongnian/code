// app factory instance
public class TestAppFactory : WebApplicationFactory<Startup>
{
    // mock for setup/verify
    public Mock<IHandler> MockHandler { get; } = new Mock<IHandler>();
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.AddSingleton(MockHandler);
        });
    }
}
public class MyTestClass : IClassFixture<TestAppFactory>
{
    private readonly TestAppFactory _factory;
    private readonly HttpClient _client;
    private readonly Mock<IHandler> _mockHandler;
    public MyTestClass(TestAppFactory factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
        _mockHandler = factory.MockHandler;
    }
    
    [Fact]
    public async Task Test()
    {
        // make calls via _client
    }
}
  [1]: https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.testing.webapplicationfactory-1?view=aspnetcore-2.2
