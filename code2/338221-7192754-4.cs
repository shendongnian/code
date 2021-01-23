    public class MyActionFilter : ActionFilterAttribute
    {
        [Injected]
        public IMyService MyService {get;set;}
        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            MyService.DoSomething();
            base.OnActionExecuting(filterContext);
        }
    }
