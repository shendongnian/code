    public class MyAuthorizationPolicyProvider: IAuthorizationPolicyProvider
    {
        private readonly DefaultAuthorizationPolicyProvider _fallbackPolicyProvider;
        internal const string PolicyPrefix = "MyJwt";
    
        public MyAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options)
        {
            _fallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }
    
    
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            return Task.FromResult<AuthorizationPolicy>(new AuthorizationPolicyBuilder(Array.Empty<string>()).RequireAuthenticatedUser().Build());
        }
    
        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
    
            if(!policyName.StartsWith(PolicyPrefix, StringComparison.OrdinalIgnoreCase))
                return _fallbackPolicyProvider.GetPolicyAsync(policyName); //here return back to static policies
    
            var authorizationPolicyBuilder = new AuthorizationPolicyBuilder(Array.Empty<string>());
            authorizationPolicyBuilder.AddRequirements((IAuthorizationRequirement)new MyAuthorizationRequirement(policyName.Substring(PolicyPrefix.Length)));
            return Task.FromResult<AuthorizationPolicy>(authorizationPolicyBuilder.Build());
        }
    }
