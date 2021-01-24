    public class CustomAuthorizeAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
    	public async Task OnAuthorizationAsync(AuthorizationFilterContext authorizationFilterContext)
    	{
    		var policyProvider = authorizationFilterContext.HttpContext
    			.RequestServices.GetService<IAuthorizationPolicyProvider>();
    		var policy = await policyProvider.GetPolicyAsync(UserPolicy.Read);
    		var requirement = (ClaimsAuthorizationRequirement)policy.Requirements
    			.First(r => r.GetType() == typeof(ClaimsAuthorizationRequirement));
    
    		if (authorizationFilterContext.HttpContext.User.Identity.IsAuthenticated)
    		{
    			if (!authorizationFilterContext.HttpContext
                  .User.HasClaim(x => x.Value == requirement.ClaimType))
    			{
    				authorizationFilterContext.Result = 
                       new ObjectResult(new ApiResponse(HttpStatusCode.Unauthorized));
    			}
    		}
    	}
    }
