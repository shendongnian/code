    public static class Policies
    {
        // This policy is internal and required for the extension method explained further below.
        // You CANNOT use this policy in your controllers or pages.
        internal static void PolicyConfigurationFailedFallback(AuthorizationPolicyBuilder builder)
            => builder.RequireAssertion(context => false);
        public static void TimeMustBeEvening(AuthorizationPolicyBuilder builder)
            => builder.RequireAuthenticatedUser()
                      .RequireAssertion(context => DateTime.UtcNow.Hour >= 18);
    }
