    class MyPolicyProvider : IAuthorizationPolicyProvider
    {
        private DefaultAuthorizationPolicyProvider BackupPolicyProvider { get; }
    
        public MyPolicyProvider()
        {
            BackupPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }
    
        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            if (policyName.Equals("Foo"))
            {
                bool myConditionToAvoidPolicy = true;
                if (myConditionToAvoidPolicy)
                {
                    return Task.FromResult<AuthorizationPolicy>(null);
                }
            }
    
            return BackupPolicyProvider.GetPolicyAsync(policyName);
        }
    }
