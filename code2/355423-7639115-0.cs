    public class VerifyResourceAccess : ActionFilterAttribute, IActionFilter
    {
    	void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
    	{
    
    		var actionAttributes = filterContext.ActionDescriptor.GetCustomAttributes(typeof(AlwaysAllowAnonymousAttribute), false);
    		var controllerAttributes = filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof(AlwaysAllowAnonymousAttribute), false);
    		bool alwaysAllow = (actionAttributes.Length > 0) || (controllerAttributes.Length > 0);
    		
    		if (!alwaysAllow) {
    			/* ... Some logic for checking if this user is allowed to access this resource  ... */
    		}
    		
    		base.OnActionExecuting(filterContext);
    	}
    }
