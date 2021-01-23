    public abstract class BaseFilter : ActionFilterAttribute
    {
    	public override void OnActionExecuting(ActionExecutingContext filterContext)
    	{
    		//user some service locator to retrieve IService1, IService2
    		
    		//some logic based on RequestType
    	}
    	
    	protected RequestType { get; set; }
    }
    
    public class SomeFilter : BaseFilter
    {
    	public SomeFilter(RequestType requestType)
    	{
    		RequestType = requestType;
    	}
    }
