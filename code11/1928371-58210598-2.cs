    public class ValidateNameParameterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionParameters.ContainsKey(name))
            {
                // the trick is to get the parameter from filter context
                string name = filterContext.ActionParameters[name] as string;
                // validate name
            }
        }
    }
