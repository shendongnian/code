    public class SetTenantIdentityHandler : AuthorizationHandler<TenantRoleRequirement>
    {
        public const string TENANT_KEY_QUERY_NAME = "tenant";
    
        private static readonly ConcurrentDictionary<string, string[]> _methodRoles = new ConcurrentDictionary<string, string[]>();
    
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TenantRoleRequirement requirement)
        {
            if (HasRoleInTenant(context))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    
        private bool HasRoleInTenant(AuthorizationHandlerContext context)
        {
            if (context.Resource is AuthorizationFilterContext authorizationFilterContext)
            {
                if (authorizationFilterContext.HttpContext
                    .Request
                    .Query
                    .TryGetValue(TENANT_KEY_QUERY_NAME, out StringValues tenant)
                    && !string.IsNullOrWhiteSpace(tenant))
                {
                    if (TryGetRoles(authorizationFilterContext, tenant.ToString().ToLower(), out string[] roles))
                    {
                        if (context.User.HasClaim(x => roles.Any(r => x.Value == r)))
                        {
                            return true;
                        }
                    }
                }
            }
    
            return false;
        }
    
        private bool TryGetRoles(AuthorizationFilterContext authorizationFilterContext,
            string tenantId,
            out string[] roles)
        {
            string actionId = authorizationFilterContext.ActionDescriptor.Id;
            roles = null;
    
            if (!_methodRoles.TryGetValue(actionId, out roles))
            {
                roles = authorizationFilterContext.Filters
                    .Where(x => x.GetType() == typeof(AuthorizeFilter))
                    .Select(x => x as AuthorizeFilter)
                    .Where(x => x != null)
                    .Select(x => x.Policy)
                    .SelectMany(x => x.Requirements)
                    .Where(x => x.GetType() == typeof(RolesAuthorizationRequirement))
                    .Select(x => x as RolesAuthorizationRequirement)
                    .SelectMany(x => x.AllowedRoles)
                    .ToArray();
    
                _methodRoles.TryAdd(actionId, roles);
            }
    
            roles = roles?.Select(x => $"{tenantId}:{x}".ToLower())
                .ToArray();
    
            return roles != null;
        }
    }
