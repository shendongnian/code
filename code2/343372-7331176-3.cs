    public override void OnAuthorization(AuthorizationContext filterContext)
    {
        var isDefinedOnAction = filterContext.ActionDescriptor.IsDefined(typeof(Anon), false);
        var isDefinedOnController = filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(Anon), false);
        if (isDefinedOnAction || isDefinedOnController)
        { 
            ... the attribute is present on either a controller or an action
            => do nothing here
        }
        else
        {
            ... perform your authorization here
        }
    }
