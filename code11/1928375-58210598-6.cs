    public class ValidateNameParameterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionParameters.ContainsKey(name))
            {
                // the trick is to get the parameter from filter context
                string name = filterContext.ActionParameters[name] as string;
                
                // validate name
 
                if (/* name is not valid*/)
                {
                    // you may want to redirect user to error page when input parameter is not valid
                    filterContext.Result = new RedirectResult(/*urlToRedirectForError*/);
                }
                base.OnActionExecuted(filterContext);
            }
        }
    }
