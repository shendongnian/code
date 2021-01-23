    public sealed class PreviewAuthAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            // todo: if site is live, show page 
            if (DataStore.Instance.Settings.Get("islive") == "True") return;
            // if request is from localhost or build server, show page
            if (filterContext.HttpContext.Request.IsLocal) return;
            if (filterContext.HttpContext.Request.UserHostAddress.StartsWith("192.168.0")) return;
            // if user has has beta role, show page
            if (filterContext.HttpContext.Request.IsAuthenticated && (filterContext.HttpContext.User.IsInRole("Beta"))) return;
        
            // site is not live and user does not have access - show placeholder
            filterContext.Result = new ViewResult()
            {                
                ViewName="Placeholder",
                ViewData = filterContext.Controller.ViewData,
                TempData = filterContext.Controller.TempData
            };
        }
        
    }
