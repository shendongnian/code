    protected override void OnException(ExceptionContext filterContext)
    {
        if (filterContext.ExceptionHandled)
        {
            return;
        }
        filterContext.Result = new ViewResult
        {
            ViewName = "~/Views/Shared/Error.aspx"
        };
        filterContext.ExceptionHandled = true;
    }
