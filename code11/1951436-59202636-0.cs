    // Marker class
    public class HasFullAccessOrAdminRequirement : IAuthorizationRequirement {}
    
    public class HasFullAccessOrAdminHandler 
    : AuthorizationHandler<HasFullAccessOrAdminRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
            HasFullAccessOrAdminRequirement requirement)
        {
			var user = context.User;
			if (user.HasClaim(...) || user.HasClaim(...))
			{
				context.Succeed(requirement);
			}
			return Task.CompletedTask;
        }
    }
