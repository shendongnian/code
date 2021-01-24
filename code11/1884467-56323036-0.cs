    public class MinimumPermissionRequirement : IAuthorizationRequirement { }
    public class MinimumPermissionHandler : AuthorizationHandler<MinimumPermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumPermissionRequirement requirement)
        {
            if (!(context.Resource is AuthorizationFilterContext filterContext))
            {
                context.Fail();
                return Task.CompletedTask;
            }
            //check if token has subjectId
            var subClaim = context.User?.Claims?.FirstOrDefault(c => c.Type == "sub");
            if (subClaim == null)
            {
                context.Fail();
                return Task.CompletedTask;
            }
            //check if token is expired
            var exp = context.User.Claims.FirstOrDefault(c => c.Type == "exp")?.Value;
            if(exp == null || new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(long.Parse(exp)).ToLocalTime() < DateTime.Now)
            {
                context.Fail();
                return Task.CompletedTask;
            }
            //other checkpoints
            //your db functions to check if user has desired claims
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
