    public class NameController : Controller
    {
	    private readonly ServiceOne _serviceOne;
        private readonly IHttpContextAccessor _context
    	public NameController(ServiceOne serviceOne, IHttpContextAccessor context)
    	{
	    	_serviceOne = serviceOne;
            _context = context;
            _context.HttpContext.Item["Service"] = _serviceOne;
	    }
    }
    public class CustomActionFilter : ActionFilterAttribute
    {
    	public string Name { get; set; }
	    public int Number { get; set; }
    	public override void OnActionExecuted(ActionExecutedContext context)
    	{
            var service = context.HttpContext.Item["Service"] as ServiceOne;
            //etc.
		}
	}
