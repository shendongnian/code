public sealed class NtlmNegotiateHandler : NegotiateHandler
{
    public NtlmNegotiateHandler(
        IOptionsMonitor<NegotiateOptions> options, 
        ILoggerFactory logger, UrlEncoder encoder, 
        ISystemClock clock) : base(options, logger, encoder, clock)
    {
    }
    protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
    {
        await base.HandleChallengeAsync(properties);
        if (Response.StatusCode ==  StatusCodes.Status401Unauthorized)
        {
            Response.Headers.Append(Microsoft.Net.Http.Headers.HeaderNames.WWWAuthenticate, "NTLM");
        }
    }
}
public sealed class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddAuthentication(NegotiateDefaults.AuthenticationScheme)
            .AddNegotiate();
        // replace the handler
        var serviceDescriptor = new ServiceDescriptor(typeof(NegotiateHandler), 
                                                      typeof(NtlmNegotiateHandler), 
                                                      ServiceLifetime.Transient);
            
        services.Replace(serviceDescriptor);
    }
}
  [1]: https://github.com/aspnet/AspNetCore/blob/master/src/Security/Authentication/Negotiate/src/NegotiateHandler.cs#L347
