    public class AdditionalViewDataInjectorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            filterContext.Controller.ViewData["foo"] = "bar";
        }
    }
