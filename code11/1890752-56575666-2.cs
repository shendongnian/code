    public class LogicalOrPolicyProvider : IAuthorizationPolicyProvider
    {
        const string POLICY_PREFIX = "Choice";
        const string TOKEN_POLICY="policy";
        const string TOKEN_ROLE="role";
        public const string Format = "Choice: policy='p3' | policy='p2' | role='role1' | ..."; 
        private AuthorizationOptions _authZOpts { get; }
        public DefaultAuthorizationPolicyProvider FallbackPolicyProvider { get; }
        public LogicalOrPolicyProvider(IOptions<AuthorizationOptions> options )
        {
            _authZOpts = options.Value;
            FallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }
        // Choice: policy= | policy= | role= | role = ...
        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            if (policyName.StartsWith(POLICY_PREFIX, StringComparison.OrdinalIgnoreCase))
            {   
                var policyNames = policyName.Substring(POLICY_PREFIX.Length);
                var startIndex = policyNames.IndexOf(":");
                if(startIndex == -1 || startIndex == policyNames.Length)
                {
                    throw new ArgumentException($"invalid syntax, must contains a ':' before tokens. The correct format is {Format}");
                }
                // skip the ":" , and turn it into the following list
                //     [[policy,policyName],[policy,policName],...[role,roleName],...,]
                var list= policyNames.Substring(startIndex+1)
                    .Split("|")
                    .Select(p => p.Split("=").Select(e => e.Trim().Trim('\'')).ToArray() )
                    ;
                // build policy for roleNames
                var rolesPolicyBuilder = new AuthorizationPolicyBuilder();
                var roleNames =list.Where(arr => arr[0].ToLower() == TOKEN_ROLE)
                    .Select(arr => arr[1])
                    .ToArray();
                var rolePolicy = rolesPolicyBuilder.RequireRole(roleNames).Build();
                // get policies with all related names
                var polices1= list.Where(arr => arr[0].ToLower() == TOKEN_POLICY);
                var polices=polices1 
                    .Select(arr => arr[1])
                    .Select(name => this._authZOpts.GetPolicy(name))  // if the policy with the name doesn exit => null
                    .Where(p => p != null)                            // filter null policy
                    .Append(rolePolicy)
                    .ToList();
                var pb= new AuthorizationPolicyBuilder();
                pb.AddRequirements(new LogicalOrRequirement(polices));
                return Task.FromResult(pb.Build());
            }
            return FallbackPolicyProvider.GetPolicyAsync(policyName);
        }
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            return FallbackPolicyProvider.GetDefaultPolicyAsync();
        }
    }
