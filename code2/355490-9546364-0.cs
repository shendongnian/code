    using System.Web.Mvc;
    using Microsoft.Practices.Unity;
    public sealed class LogOnAuthorize :  AuthorizeAttribute
    {
    [Dependency]
    public Service.IDaoService dao { get; set; }
    public override void OnAuthorization(AuthorizationContext filterContext)
    {
        string SessionKey = "ProfileCompleted";
        bool Authorization = filterContext.ActionDescriptor.IsDefined(typeof(AuthorizeAttribute), true)
            || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AuthorizeAttribute), true);
        bool ContainsIgnore = filterContext.ActionDescriptor.IsDefined(typeof(IgnoreCompleteProfileAttribute), true)
            || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(IgnoreCompleteProfileAttribute), true);
        
        if ((Authorization) && (!ContainsIgnore))
        {
            var ctx = System.Web.HttpContext.Current;
            if (ctx != null)
            {
                if (filterContext.HttpContext.User.Identity.IsAuthenticated) 
                {
                    if (ctx.Session[SessionKey] == null)
                    {
                        Models.UserDetail user = dao.UserDao.GetByEmail(filterContext.HttpContext.User.Identity.Name);
                        if (user != null)
                            ctx.Session[SessionKey] = user.CompletedAccount;
                    }
                    bool ForceRedirect = ((ctx.Session[SessionKey] == null) || ((bool)ctx.Session[SessionKey] == false));
                    string ReturnUrl = string.Empty;
                    if ((filterContext.HttpContext.Request != null) && (!string.IsNullOrEmpty(filterContext.HttpContext.Request.RawUrl)))
                        ReturnUrl = filterContext.HttpContext.Request.RawUrl.ToString();
                    if (ForceRedirect)
                        filterContext.Result = new RedirectToRouteResult("CompleteAccount", new System.Web.Routing.RouteValueDictionary {  {"ReturnUrl" , ReturnUrl} });
                }
                else
                    base.OnAuthorization(filterContext);
            }
            else
                base.OnAuthorization(filterContext);
        }
    }
    }
