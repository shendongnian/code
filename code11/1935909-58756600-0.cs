public class TestAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public TestAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
        : base(options, logger, encoder, clock)
    {
    }
    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var claims = new[] { new Claim(ClaimTypes.Name, "Test user") };
        var identity = new ClaimsIdentity(claims, "Test");
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, "Test");
        AuthenticateResult result = AuthenticateResult.Success(ticket);
        return Task.FromResult(result);
    }
}
Then in the `ConfigureTestServices` I changed the logic from
services.AddControllers(options =>
    {
        options.Filters.Add(new AllowAnonymousFilter());
    });
to add an Authentication and override the Authorization Policy as such:
services
    .AddAuthentication("Test")
    .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>("Test", options => { });
services.AddAuthorization(options =>
{
    options.AddPolicy("<Existing Policy Name>", builder =>
    {
        builder.AuthenticationSchemes.Add("Test");
        builder.RequireAuthenticatedUser();
    });
    options.DefaultPolicy = options.GetPolicy("<Existing Policy Name>");
});
This now allowed my tests to work under .NET Core 3.0.
