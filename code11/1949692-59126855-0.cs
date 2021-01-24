lang-c#
public class CreateClientHandler : AuthorizationHandler<CreateClientRequirement, CreateClientRequest>, IAuthorizationRequirement
    {
        private readonly IStudioService _studioService;
        public CreateClientHandler(
            IStudioService studioService
        )
        {
            _studioService = studioService;
        }
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            CreateClientRequirement requirement,
            CreateClientRequest resource
        )
        {
            var userIdClaim = context.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Name);
            if (userIdClaim == null)
            {
                context.Fail();
                return Task.CompletedTask;
            }
            if (resource != null)
            {
                var userId = int.Parse(userIdClaim.Value);
                if (!UserIsAdmin(userId))
                {
                    context.Fail();
                    return Task.CompletedTask;
                }
            }
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
    public class CreateClientRequirement : IAuthorizationRequirement {}
In my `ConfigureServices`, in `Startup.cs`:
lang-c#
services.AddAuthorization(options =>
    {
        options.AddPolicy("CreateClient", policy =>
            policy.Requirements.Add(new CreateClientRequirement()));
    });
Once everything is configured, I can decorate controller actions with `[Authorize(Policy = "CreateClient")]`.
