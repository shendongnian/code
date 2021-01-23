    public class FooBarController : Controller
    {
        
        //this is easy as compared to edit
        [Authorized]
        public ActionResult Create()
        {
        }
        [AjaxAuthorize(Roles = "Administrator")]    
        public ActionResult Edit(int id)
        {
        }
    }
    public class AjaxAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var id = filterContext.RouteData.Values["id"];
            // Here you can check if the id belongs to logged in user
            var content = SomeRepository.GetById(id);
            if (contet.OwnerId=LoggedInUser.Id)
               return;
            //otherwise check if logged in user is from some Admin or other role.
            string redirectPage = "/account/logon";
            var roles = base.Roles.Trim().Split(',');
            bool CanAccess = false;
            //If no role is there
            if (base.Roles.Equals(string.Empty) || roles.Count() == 0)
            {
                CanAccess = true;
            }
            else
            {
                foreach (var item in roles)
                {
                    CanAccess = filterContext.HttpContext.User.IsInRole(item);
                    if (CanAccess)
                        break;
                }
            }
            var request = filterContext.RequestContext.HttpContext.Request;
            if (request.IsAjaxRequest())
            {
                if (!(request.IsAuthenticated && CanAccess))
                {
                    filterContext.Result = new AjaxAwareRedirectResult(redirectPage);
                    return;
                }
            }
            base.OnAuthorization(filterContext);
        }
    }
    public class AjaxAwareRedirectResult : RedirectResult
    {
        public AjaxAwareRedirectResult(string url)
            : base(url)
        {
        }
        public override void ExecuteResult(ControllerContext context)
        {
            if (context.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                string destinationUrl = UrlHelper.GenerateContentUrl(Url, context.HttpContext);
                JavaScriptResult result = new JavaScriptResult()
                {
                    Script = "window.location='" + destinationUrl + "';"
                };
                result.ExecuteResult(context);
            }
            else
                base.ExecuteResult(context);
        }
    }
