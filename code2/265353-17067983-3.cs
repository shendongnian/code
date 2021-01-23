    [AttributeUsage(AttributeTargets.All)]
    public class IgnoreValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var modelState = filterContext.Controller.ViewData.ModelState;
            foreach (var modelValue in modelState.Values)
            {
                modelValue.Errors.Clear();
            }
        }
    }
