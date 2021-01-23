    protected override void OnActionExecuted(ActionExecutedContext filterContext)
    {
        var viewModel = filterContext.Controller.ViewData.Model as ViewModelBase;
        if (viewModel != null)
        {
            viewModel.ClientSettings = ClientSettings;
        }
        base.OnActionExecuted(filterContext);
    }
