await context.HttpContext?.GetTokenAsync("id_token")
Send that along in your API calls as part of the header using via the standard mechanism:
"Authorization" : "Bearer [token]"
On the Web API side, you use the same Okta.AspNetCore middleware package and can then decorate your controllers with [Authorize] to enforce auth on them. Here is where I got tripped up. If you are *not* using the default auth server in Okta and have setup a custom one for your application, you need to specific it and the audience in your config:
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = OktaDefaults.ApiAuthenticationScheme;
                options.DefaultChallengeScheme = OktaDefaults.ApiAuthenticationScheme;
                options.DefaultSignInScheme = OktaDefaults.ApiAuthenticationScheme;
            })
            .AddOktaWebApi(new OktaWebApiOptions()
            {
                OktaDomain = oktaDomain,
                AuthorizationServerId = authServerId,
                Audience = clientId
            });
            services.AddAuthorization();
I had complete forgotten about the audience part - and with the way token validation works, that part is required. 
From there, the middleware takes care of populating an ClaimsPrincipal for you, so you can access user information via the ClaimsPrincipal (HttpContext.User). I ended up creating a "CurrentUserService" and pulled it out into its own library so that I can consolidate all my auth handlers there; thereby allowing my web app and web api code to check permissions and retrieve information about the current user in the same way. That code is here if you're interested:
    public interface ICurrentUserService
    {
        public ClaimsPrincipal GetCurrentUser();
        public string GetCurrentUserDisplayName();
        public string GetCurrentUserFullName();
        public string GetCurrentUserId();
        public DateTime? GetCurrentUserDob();
        public string GetCurrentUserGender();
        public AddressFromClaimsDTO GetCurentUserAddress();
        public bool IsAuthenticated();
    }
    public class CurrentUserService : ICurrentUserService
    {
        private const string FULL_ADDRESS_CLAIM_TYPE = "address";
        private readonly IHttpContextAccessor _context;
        public CurrentUserService(IHttpContextAccessor context)
        {
            _context = context;
        }
        /// <summary>
        /// Gets whether or not the current user context is authenticated.
        /// </summary>
        /// <returns></returns>
        public bool IsAuthenticated()
        {
            return GetCurrentUser().Identity.IsAuthenticated;
        }
        /// <summary>
        /// Gets the current user's address.
        /// TODO: tie this into our address data model... but if addresses live in Okta what does that mean?
        /// </summary>
        /// <returns></returns>
        public AddressFromClaimsDTO GetCurentUserAddress()
        {
            var addressClaim = GetClaim(FULL_ADDRESS_CLAIM_TYPE);
            if (addressClaim != null)
            {
                //var parseValue = addressClaim.Value.ToString().Replace("{address:", "{\"address\":");
                var address = JsonSerializer.Deserialize<AddressFromClaimsDTO>(addressClaim.Value.ToString());
                return address;
            }
            else
            {
                return new AddressFromClaimsDTO();
            }
        }
        public ClaimsPrincipal GetCurrentUser()
        {
            return _context.HttpContext.User;
        }
        public string GetCurrentUserDisplayName()
        {
            return GetCurrentUser().Identity.Name;
        }
        public string GetCurrentUserFullName()
        {
            throw new NotImplementedException();
        }
        public string GetCurrentUserId()
        {
            throw new NotImplementedException();
        }
        public DateTime? GetCurrentUserDob()
        {
            var claim = GetClaim("birthdate");
            if (claim != null && !string.IsNullOrEmpty(claim.Value))
            {
                return DateTime.Parse(claim.Value);
            }
            else
            {
                return null;
            }
        }
        public string GetCurrentUserGender()
        {
            return GetClaim("gender")?.Value.ToString();
        }
        public Claim GetClaim(string claimType)
        {
            return _context.HttpContext.User.FindFirst(x => x.Type == claimType);
        }
    }
