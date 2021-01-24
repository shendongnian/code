    public class MyCustomAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public PlatformAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options, 
            ILoggerFactory logger, 
            UrlEncoder encoder,
            ISystemClock clock) 
            : base(options, logger, encoder, clock)
        {
        }
    
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            //Send your request to your API and return either 
            //AuthenticateResult.Fail
            //return AuthenticateResult.Success
        }
    }
