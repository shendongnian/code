    public class NameController : Controller
    {
	    private readonly ServiceOne _serviceOne;
        public ServiceOne ServiceOne => _serviceOne;
    	public NameController(ServiceOne serviceOne)
    	{
	    	_serviceOne = serviceOne;
	    }
    }
    public class CustomActionFilter : ActionFilterAttribute
    {
    	public string Name { get; set; }
	    public int Number { get; set; }
    	public override void OnActionExecuted(ActionExecutedContext context)
    	{
            var controller = context.Controller as NameController;
            var service = controller.ServiceOne;
            //Use the service here
		}
	}
