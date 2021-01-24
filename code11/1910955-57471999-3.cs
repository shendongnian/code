    public class BaseAuthAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = new BusinessLayer.PortalUser(filterContext.HttpContext.Request.Cookies["appname"]);
            if (!session.IsAuthorized()
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
