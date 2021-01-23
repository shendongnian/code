    public class PromoteAttribute : ActionFilterAttribute
    {
        string[] expressions;
        public PromoteAttribute(string toPromote)
        {
            expressions = toPromote.Split(' ');
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ModelStateDictionary modelState=filterContext.Controller.ViewData.ModelState;
            foreach(var x in expressions)
            {
                if (modelState.ContainsKey(x))
                {
                    var entry = modelState[x];
                    if (entry.Errors.Count == 0) continue; 
                    
                    foreach (var error in entry.Errors) modelState.AddModelError("", error.ErrorMessage);
                    
                }
            }
        }
    }
