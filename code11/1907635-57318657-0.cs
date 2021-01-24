public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup> where TStartup : class
{
    public CustomWebApplicationFactory() { }
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder
            .ConfigureTestServices(
                services =>
                {
                    services.Configure(AzureADDefaults.OpenIdScheme, (System.Action<OpenIdConnectOptions>)(o =>
                    {
                        // CookieContainer doesn't allow cookies from other paths
                        o.CorrelationCookie.Path = "/";
                        o.NonceCookie.Path = "/";
                    }));
                }
            )
            .UseEnvironment("Production")
            .UseStartup<Startup>();
    }
}
public class AuthenticationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
{
    private HttpClient _httpClient { get; }
    public AuthenticationTests(CustomWebApplicationFactory<Startup> fixture)
    {
        WebApplicationFactoryClientOptions webAppFactoryClientOptions = new WebApplicationFactoryClientOptions
        {
            // Disallow redirect so that we can check the following: Status code is redirect and redirect url is login url
            // As per https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-2.2#test-a-secure-endpoint
            AllowAutoRedirect = false
        };
        _httpClient = fixture.CreateClient(webAppFactoryClientOptions);
    }
    [Theory]
    [InlineData("/")]
    [InlineData("/Index")]
    [InlineData("/Error")]
    public async Task Get_PagesNotRequiringAuthenticationWithoutAuthentication_ReturnsSuccessCode(string url)
    {
        // Act
        HttpResponseMessage response = await _httpClient.GetAsync(url);
        // Assert
        response.EnsureSuccessStatusCode();
    }
}
I followed the guide [here](https://fullstackmark.com/post/20/painless-integration-testing-with-aspnet-core-web-api) to get this working in my own code.
