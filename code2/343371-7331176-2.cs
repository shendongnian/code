    public override void OnAuthorization(AuthorizationContext filterContext)
    {
        var isDefinedOnAction = filterContext.ActionDescriptor.IsDefined(typeof(Anon), false);
        var isDefinedOnController = filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(Anon), false);
        if (!isDefinedOnAction && !isDefinedOnController)
        {
            ... the Anon attribute is not present neither on an action nor on a controller
            => perform your authorization here
        }
    }
