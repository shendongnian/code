    protected override void OnActionExecuted(ActionExecutedContext filterContext)
    {
        if (filterContext.Exception is RepositoryException)
        {
            filterContext.ExceptionHandled = true;
            filterContext.Result = View("Exception", filterContext.Exception);
        }
        base.OnActionExecuted(filterContext);
    }
