    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        if (!settings.Enabled)
        {
            // Because we are assigning a Result here the action will be 
            // short-circuited and will never execute neither the OnActionExecuted
            // method of the filer. The NotFound view will be directly rendered
            filterContext.Result = new ViewResult
            {
                ViewName = "NotFound",
                MasterName = GetMasterName()
            };
        }
    }
