    public override void OnActionExecuted(ActionExecutedContext filterContext)
    {
        base.OnActionExecuted(filterContext);
        var viewResult = filterContext.Result as ViewResultBase;
        if (viewResult != null) 
        {
            var model = viewResult.ViewData.Model as BaseViewModel;
            if (model != null)
            {
                model.MenuLinks = _repository.GetMenuLinks();
            }
        }
    }
