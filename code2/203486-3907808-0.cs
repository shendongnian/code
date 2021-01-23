        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            if (filterContext.Canceled || filterContext.Exception != null)
                return;
                
             var viewResult = filterContext.Result as ViewResult;
             var viewModel = new BaseViewModel();
             PopulateBaseViewModel(viewModel);
             viewResult.ViewData["baseModel"] = viewModel;            
        }
