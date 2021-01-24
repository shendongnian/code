    public class ValidateNameParameterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionArguments.ContainsKey("name"))
            {
                string name = filterContext.ActionArguments["name"] as string;
                if(name!=null && name.Length>10)
                {
                    filterContext.Result = new BadRequestObjectResult("The length of name must not exceed 10");
                }
            }
        }
    }
