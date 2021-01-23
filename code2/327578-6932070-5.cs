    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {
                if (!controller.PortalSession.ValidSession)
                {
                    base.HandleUnauthorizedRequest(filterContext);
                }
                else
                {
                    if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                    {
                        //base.HandleUnauthorizedRequest(filterContext);
                        filterContext.RequestContext.HttpContext.Response.StatusCode = 403;
                        var result = new JsonResult();
                        result.Data = new {Success=false};
                        result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                        filterContext.Result = result;
                        return;
                    }
    
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary
                            {
                                {"controller", MVC.Login.Name},
                                {"action", MVC.Login.ActionNames.NotAuthorized},
                                {"group", RequiredRole}
                            });
                }
    
    
            }
