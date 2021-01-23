    public class MyActionFilter : IActionFilter
    {
        private readonly IMyService myService;
        public MyActionFilter(IMyService myService)
        {
            this.myService = myService;
        }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(this.ApplyBehavior(filterContext))
                this.myService.DoSomething();
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if(this.ApplyBehavior(filterContext))
                this.myService.DoSomething();
        }
        private bool ApplyBehavior(ActionExecutingContext filterContext)
        {
            // Look for a marker attribute in the filterContext or use some other rule
            // to determine whether or not to apply the behavior.
        }
        private bool ApplyBehavior(ActionExecutedContext filterContext)
        {
            // Same as above
        }
    }
