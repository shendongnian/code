    public class MyActionFilter : ActionFilterAttribute
    {
        private IMyService _myService;
        
        public MyActionFilter() // Call this one when decorating actions with the attribute
        {
        }
        
        // The system should create a new instance using this constructor, if you're using
        // Ninject's MVC extension.
        public MyActionFilter(IMyService myService) 
        {
            _myService = myService;
        }
        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _myService.DoSomething();
            base.OnActionExecuting(filterContext);
        }
    }
