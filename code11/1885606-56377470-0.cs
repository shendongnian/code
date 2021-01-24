c#
[AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
public class CustomActionAttribute : FilterAttribute, IActionFilter, IResultFilter
{
    public string ParamName { get; set; }
    public void OnActionExecuted(ActionExecutedContext filterContext)
    {
        throw new NotImplementedException();
    }
    public void OnActionExecuting(ActionExecutingContext filterContext)
    {
        if (filterContext.ActionParameters.ContainsKey(ParamName))
        {
            try
            {
                var model = filterContext.ActionParameters[ParamName] as authModel;
                bool isUserExist = externalApp.isUserExist(model.userName, model.Password);
                if (isUserExist)
                    // this code let you to go on without checking authorization.
                    return;
            }
            catch
            {
            }
        }
        filterContext.Result = new ViewResult
        {
            ViewName = "~/Views/Shared/UnAuthorizeAction.cshtml",
        };
    }
    public void OnResultExecuted(ResultExecutedContext filterContext)
    {
        throw new NotImplementedException();
    }
    public void OnResultExecuting(ResultExecutingContext filterContext)
    {
        throw new NotImplementedException();
    }
}
And here it's usage:
c# 
[CustomActionAttribute(IdParamName = model)]
public ActionResult DefaultAction(authModel model)
{
    //...
}
