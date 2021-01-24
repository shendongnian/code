    public class CustomAuthOptions: AuthenticationSchemeOptions
    {
    }
b. Declare a class implementing the ` AuthenticationHandler<TOptions>`
    internal class CustomAuthHandler : AuthenticationHandler<CustomAuthOptions>
    {
        IHttpContextAccessor _httpContextAccessor;
        IUser _user;
        public CustomAuthHandler(IOptionsMonitor<CustomAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, 
            IHttpContextAccessor httpContextAccessor, IUser user) : base(options, logger, encoder, clock)
        {
            _httpContextAccessor = httpContextAccessor;
            _user = user;
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            //logic to authenticate
        }
        protected override Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            //more code
        }
   }
c. Add an extension method to the `AuthenticationBuilder` class 
        public static AuthenticationBuilder AddCustomAuth(this AuthenticationBuilder builder,
            Action<CustomAuthOptions> config)
        {
            return builder.AddScheme<CustomAuthOptions, CustomAuthHandler>("CheckInDB", "CheckInDB", config);
        }
d. Finally in the `Startup.cs`
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "CheckInDB";
                options.DefaultChallengeScheme = "CheckInDB";
            }).AddCustomAuth(c => { });
This may be more than what is needed, but when I was in the same boat, a couple of months ago, I spent a good few days piecing all of this together.
