public const string POLICY_JWT = "jwtPolicy";
public const string POLICY_AUTHORIZE_WHEN_HAS_BEARER = "authorizeWhenHasBearer";
Setting up the policies:
services.AddAuthorization(o =>
            {
                o.AddPolicy(AuthFilterConvension.POLICY_JWT, b =>
                {
                    b.RequireRole("Admin");
                    b.RequireAuthenticatedUser();
                    b.AuthenticationSchemes = new List<string> {JwtBearerDefaults.AuthenticationScheme};
                    
                });
            }); 
Add custom attribute:
    public class AuthorizeBearerWhenPresent : AuthorizeAttribute
    {
        public AuthorizeBearerWhenPresent()
        {
            Policy = AuthFilterConvension.POLICY_AUTHORIZE_WHEN_HAS_BEARER;
        }
    }
The name POLICY_AUTHORIZE_WHEN_HAS_BEARER is not configured, but only used as a key in my ```CustomPolicyProvicer```:
public class CustomPolicyProvider : IAuthorizationPolicyProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DefaultAuthorizationPolicyProvider _fallbackPolicyProvider;
        public CustomPolicyProvider(IHttpContextAccessor httpContextAccessor, IOptions<AuthorizationOptions> options)
        {
            _httpContextAccessor = httpContextAccessor;
            _fallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }
        
        public async Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            if (AuthFilterConvension.POLICY_AUTHORIZE_WHEN_HAS_BEARER.Equals(policyName))
            {
                if (_httpContextAccessor.HttpContext.Request.Headers.ContainsKey("Authorization"))
                {
                    return await _fallbackPolicyProvider.GetPolicyAsync(AuthFilterConvension.POLICY_JWT);    
                }
                return new AuthorizationPolicyBuilder()
                    .RequireAssertion(x=>true)
                    .Build();
            }
            
            return await _fallbackPolicyProvider.GetPolicyAsync(policyName);
        }
        public async Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            return await _fallbackPolicyProvider.GetDefaultPolicyAsync();
        }
    }
This way I can avoid doing custom handling of the JWT tokens
The following:
return new AuthorizationPolicyBuilder()
  .RequireAssertion(x=>true)
  .Build();
Is only used as a dummy "allow all"
