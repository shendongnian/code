    public class ResourceOwnerRequirement : IAuthorizationRequirement
    {
    }
    public class ResourceOwnerHandler 
        : AuthorizationHandler<ResourceOwnerRequirement, MyBusinessObject>
        //: AuthorizationHandler<ResourceOwnerRequirement> use this overload to handle all types of resources...
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            ResourceOwnerRequirement requirement, 
            MyBusinessObject resource)
        {
            int createdByUserId = resource.CreatedBy;
            Claim userIdClaim = ((ClaimsIdentity)context.User.Identity).FindFirst("UserId");
            if (int.TryParse(userIdClaim.Value, out int userId)
                && createdByUserId == userId)
            {
                context.Succeed(requirement);
            }
        }
    }
    //admin can do anything
    public class AdminRequirementHandler : IAuthorizationHandler
    {
        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            if (context.User.Claims.Any(c => c.Type == "Role" && c.Value == "Administator"))
            {
                while (context.PendingRequirements.Any())
                {
                    context.Succeed(context.PendingRequirements.First());
                }
            }
            return Task.CompletedTask;
        }
    }
