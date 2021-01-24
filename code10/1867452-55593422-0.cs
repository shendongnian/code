    public class MyFilter : TypeFilterAttribute
    {
        public MyFilter() : base(typeof(MyFilterImpl))
        {
        }
    }
    public class MyFilterImpl : IActionFilter
    {
        private readonly IDependency _dependency;
        public MyFilterImpl(IDependency injected)
        {
            _dependency = injected;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _dependency.DoThing();
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
