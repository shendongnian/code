    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, 
                    Inherited = false)]
    public abstract class RespondWithModelErrorsAttribute : ActionFilterAttribute
    {
      public override void OnActionExecuting(ActionExecutingContext filterContext)
      {
        ModelStateDictionary modelState = 
          filterContext.Controller.ViewData.ModelState;
        if (modelState.Any(kvp => kvp.Value.Errors.Count > 0))
          filterContext.Result = CreateResult(filterContext, 
                         modelState.Where(kvp => kvp.Value.Errors.Count > 0));
        base.OnActionExecuting(filterContext);
      }
      public abstract ActionResult CreateResult(
        ActionExecutingContext filterContext, 
        IEnumerable<KeyValuePair<string, ModelState>> modelStateWithErrors);
    }
