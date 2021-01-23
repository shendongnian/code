    public class RequiresStateList : ActionFilterAttribute {
        public override void OnResultExecuting(ResultExecutingContext filterContext) 
        {
            filterContext.Controller.ViewData["StateList"] = GetStates();
        }
    }
