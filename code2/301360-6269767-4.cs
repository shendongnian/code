    public UserPermissionRequiredAttribute: AuthorizeAttribute
    {
    public OnAuthorization(AuthorizationContext filterContext)
    {
    var isAuthenticated = filterContext.HttpContext.User.Identity.IsAuthenticated;
    var userName = filterContext.HttpContext.User.Identity.Name;
    var actionName = filterContext.ActionDescriptior.ActionName;
    var controllerName = filterContext.ActionDescriptior.ControllerDescriptor.ControllerName;
        if (isAuthenticated && myUserActionPermissionsService.UserCanAccessAction(userName, actionName, contollerName)
    {
    filterContext.Result = HttpUnauthorizedResult(); // aborts action executing
    }
    }
    }
