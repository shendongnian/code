    public static void AddAdminPolicy(AuthorizationOptions options)
    {
        options.AddPolicy(AuthorizationPolicies.Admin, p => BuildPolicy(p, new [] { Permissions.Admin, Permissions.Viewer }));
    }
    private static void BuildPolicy(AuthorizationPolicyBuilder policy, int[] permissions)
    {
        policy.AddAuthenticationSchemes(Defaults.SchemeName); 
        policy.AddRequirements(new AuthorizationRequirement
        {
            Require = Access.Always,
            PermissionsRequired = permissions
        });
    }
