       public override void OnActionExecuting(ActionExecutingContext filterContext)
       {
           var controller = (SomeControllerBase)filterContext.Controller;
           filterContext.Result = controller.RedirectToAction("index","home")
       }
