    protected override void OnException(ExceptionContext filterContext)
    {
      filterContext.ExceptionHandled = true;
	  //Redirect or return a view, but not both.
      filterContext.Result = RedirectToAction("Index", "Home");
      // OR 
      filterContext.Result = new ViewResult
      {
         ViewName = "~/Views/Shared/Error.cshtml"
      };
    }
