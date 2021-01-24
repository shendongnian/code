    public void OnAuthorization(AuthorizationFilterContext context)
    {
        //..
        Type localizerType = GetLocalizerType(context);
        IStringLocalizer localizer = (IStringLocalizer)context.HttpContext.RequestServices.GetService(localizerType);
        //..
    }
    private Type GetLocalizerType(AuthorizationFilterContext context)
    {
        var controllerType = (context.ActionDescriptor as ControllerActionDescriptor).ControllerTypeInfo;
        return typeof(IStringLocalizer<>).MakeGenericType(controllerType);
    }
