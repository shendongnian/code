    public class UserMvcController : Controller
       {
          protected override void OnException(ExceptionContext filterContext)
          {
             filterContext.ExceptionHandled = true;
    
    	     //Log the error!!
             _Logger.Error(filterContext.Exception);
    
             //Redirect
             filterContext.Result = RedirectToAction("Index", "ErrorHandler");
             {
                ViewName = "~/Views/ErrorHandler/Index.cshtml"
             };
          }
       }
