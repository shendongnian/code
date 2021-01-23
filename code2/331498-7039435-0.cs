    public override void OnAuthorization(System.Web.Mvc.AuthorizationContext filterContext)
        {
            // Want to redirect to route here.
            filterContext.Result = new RedirectToRouteResult("routename", routeValues)
    
            base.OnAuthorization(filterContext);
        }
