    public class CustomError
    {
    	public string Error { get; }
    	
    	public CustomError(string message)
    	{
    		Error = message;
    	}
    }
    
    public class CustomUnauthorizedResult : JsonResult
    {
    	public CustomUnauthorizedResult(string message, int statusCode) : base(new CustomError(message))
    	{
    		StatusCode = statusCode;
    	}
    }
    
    public class ClaimRequirementFilter : Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter
    {
    	public void OnAuthorization(AuthorizationFilterContext context)
    	{
    		context.Result = new CustomUnauthorizedResult("Authorization failed.", statusCode:403);
    	}
    }
