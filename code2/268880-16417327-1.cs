    public class AuthorizeActionFilterAttribute : ActionFilterAttribute
    {
      public override void OnActionExecuting(FilterExecutingContext filterContext)
      {
        HttpSessionStateBase session = filterContext.HttpContext.Session;
        Controller controller = filterContext.Controller as Controller;
                     
        if (controller != null)
        {
          if (session["Login"] == null)
          {
            filterContext.Cancel = true;
            controller.HttpContext.Response.Redirect("./Login");
          }
        }
        base.OnActionExecuting(filterContext);
      }
    }
