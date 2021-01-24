    public class CustomUserPolicyRequirementHandler : AuthorizationHandler<CustomUserRequirement>
    {
    	private readonly IUserService _userService;
    
    	public MeetingsPolicyRequirementHandler(
    		IUserService userService)
    	{
    		_userService = userService;
    	}
    
    	protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomUserRequirement requirement)
    	{
    		if (!context.HasFailed)
    		{
    			if (_userService.DoesUserExistInMyCustomTable(context.User))
    			{
    				context.Succeed(requirement);
    			}
    			else
    			{
    				context.Fail();
    			}
    		}
    		return Task.CompletedTask;
    	}
    }
    
    public class CustomUserRequirement : IAuthorizationRequirement { }
