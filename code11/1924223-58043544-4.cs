    public class AuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider
    {
        public AuthorizationPolicyProvider(IOptions<AuthorizationOptions> options) : base(options)
        {
        }
        public async override Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            // check static policies first
            var policy = await base.GetPolicyAsync(policyName);
            if (policy == null)
                return new AuthorizationPolicyBuilder().AddRequirements(new PermissionRequirement(policyName)).Build();
            return policy;
        }
    }
