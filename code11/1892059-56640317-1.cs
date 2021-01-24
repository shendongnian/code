    internal class ClaimCheckerPolicyProvider : IAuthorizationPolicyProvider
    {
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            return Task.FromResult(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build());
        }
        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            if (IsClaimBasePolicy(policyName))
            {
                string[] parts = GetParts(policyName);
                if (parts.Length > 0)
                {
                    AuthorizationPolicyBuilder policy = GetPolicyBuilder(parts);
                    return Task.FromResult(policy.Build());
                }
            }
            return Task.FromResult<AuthorizationPolicy>(null);
        }
        private bool IsClaimBasePolicy(string policyName)
        {
            return !string.IsNullOrWhiteSpace(policyName)
                            && policyName.StartsWith(HasPermissionAttribute.Policy_Prefix, StringComparison.OrdinalIgnoreCase);
        }
        private string[] GetParts(string policyName)
        {
            return policyName.Split(HasPermissionAttribute.Policy_Glue, StringSplitOptions.RemoveEmptyEntries)
                             .Where(x => !x.Equals(HasPermissionAttribute.Policy_Prefix))
                             .ToArray();
        }
        private AuthorizationPolicyBuilder GetPolicyBuilder(string[] parts)
        {
            if (parts == null)
            {
                throw new ArgumentNullException($"{nameof(parts)} cannot be null.");
            }
            var length = parts.Length;
            if (length == 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(parts)} cannot cannot be empty.");
            }
            var policy = new AuthorizationPolicyBuilder();
            if (length > 1)
            {
                return policy.RequireClaim(parts[0], parts[1]);
            }
            return policy.RequireClaim(parts[0]);
        }
    }
