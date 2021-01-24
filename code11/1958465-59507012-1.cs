    public class AuthenticationTokenOptions : AuthenticationSchemeOptions
    {
    }
    public class AuthenticationTokenHandler : AuthenticationHandler<AuthenticationTokenOptions>
    {
        private readonly string expectedAuthenticationToken;
        public AuthenticationTokenHandler(IOptionsMonitor<AuthenticationTokenOptions> optionsMonitor,
            ILoggerFactory loggerFactory, UrlEncoder urlEncoder, ISystemClock systemClock,
            IConfiguration config)
            : base(optionsMonitor, loggerFactory, urlEncoder, systemClock)
        {
            this.expectedAuthenticationToken = config.GetSection("ExpectedAuthenticationToken").Get<string>();
        }
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var authenticationToken = this.Request.getRequestHeader("authenticationToken");
            if (string.IsNullOrWhiteSpace(authenticationToken))
                return Task.FromResult(AuthenticateResult.NoResult());
            if (this.expectedAuthenticationToken != authenticationToken)
                return Task.FromResult(AuthenticateResult.Fail("Unknown Client"));
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(Enumerable.Empty<Claim>(), Scheme.Name));
            var authenticationTicket = new AuthenticationTicket(claimsPrincipal, Scheme.Name);
            return Task.FromResult(AuthenticateResult.Success(authenticationTicket));
        }
    }
