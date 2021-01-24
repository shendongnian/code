    public class MVCError : HandleErrorAttribute
        {
            public override void OnException(ExceptionContext filterContext)
            {
                 //Supposed to remove session here
                 HttpContext.Current.Session.Remove("Check");
            }
        }
