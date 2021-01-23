    	[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
	    public class Securitycheck : ActionFilterAttribute {
		    public Securitycheck (String key, String sig) {
		    }
		    public override void OnActionExecuting(ActionExecutingContext filterContext) {
			    base.OnActionExecuting(filterContext);
			    if (failed) {
			       filterContext.Result = new RedirectResult(redirect);
                }
		    }
	    }
