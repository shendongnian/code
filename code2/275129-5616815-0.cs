    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
       if (!filterContext.Controller.ViewData.ModelState.IsValid)
          return;
       
       var model = filterContext.ActionParameters.SingleOrDefault(ap => ap.Key == "model").Value;
       if (model != null)
       {
          // Found the model - add it to tempdata
          filterContext.Controller.TempData.Add(TempDataKey, model);
       }
    }
