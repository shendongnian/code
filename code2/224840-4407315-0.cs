    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        base.OnActionExecuting(filterContext);
        if (filterContext.ActionDescriptor.ActionName == "About")
            filterContext.Result = RedirectToAction("Index");
    }
