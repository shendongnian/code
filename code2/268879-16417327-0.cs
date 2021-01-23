     public class AuthorizeActionFilterAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(FilterExecutingContext filterContext)
            {
               HttpSessionStateBase session = filterContext.HttpContext.Session;
               Controller control = filterContext.Controller as Controller;
          
             
                if (control != null)
                {
                    if (session["Login"] == null)
                    {
                        filterContext.Cancel = true;
                        control.HttpContext.Response.Redirect("./Login");
    
                    }
                }
                base.OnActionExecuting(filterContext);
            }
        }
