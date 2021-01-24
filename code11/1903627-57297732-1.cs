    public static class AuthorizationOptionsExtension
    {
        public static void AddSharedPolicies(this AuthorizationOptions options,
                                             ILogger logger)
        {
            logger.LogInformation($"{nameof(AuthorizationPolicy)} Configuration started ...");
            var policies = FindPolicies();
            options.TryToAddPolicies(policies, logger);
            logger.LogInformation($"{nameof(AuthorizationPolicy)} Configuration completed.");
        }
        private static IEnumerable<PolicyInformation> FindPolicies()
        {
            var policyProvider = typeof(Policies);
            return from method in policyProvider.GetMethods(BindingFlags.Public | BindingFlags.Static)
                   // The method should configure the policy builder, not return a built policy.
                   where method.ReturnType == typeof(void)
                   let methodParameter = method.GetParameters()
                   // The method has to accept the AuthorizationPolicyBuilder, and no other parameter.
                   where methodParameter.Length == 1 && methodParameter[0].ParameterType == typeof(AuthorizationPolicyBuilder)
                   select new PolicyInformation(method.Name, method);
        }
        private static void TryToAddPolicies(this AuthorizationOptions options,
                                             IEnumerable<PolicyInformation> policies,
                                             ILogger logger)
        {
            foreach (var policy in policies)
            {
                try
                {
                    options.AddPolicy(policy.Name, builder => { policy.Method.Invoke(null, new object[] {builder}); });
                    logger.LogInformation($"Policy '{policy.Name}' was configured successfully.");
                }
                catch (Exception e)
                {
                    options.AddPolicy(policy.Name, Policies.PolicyConfigurationFailedFallback);
                    logger.LogCritical(e, $"Failed to configure policy '{policy.Name}'. Using fallback policy instead.");
                }
            }
        }
        private class PolicyInformation
        {
            internal string Name { get; }
            internal MethodInfo Method { get; }
            internal PolicyInformation(string name,
                                       MethodInfo method)
            {
                Name = name;
                Method = method;
            }
        }
    }
