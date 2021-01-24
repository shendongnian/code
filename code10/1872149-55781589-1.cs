    public AccessPermissionEnum PermissionRequired { get; set; }
    public string UserIdsKey { get; set; }
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Depending on how you pass your userIds to the action, you
        // may need to use something else from context to get the data,
        // but it's all available in there.
        var userIds = context.ActionArguments[UserIdsKey];
        // Do something with the ids.
        base.OnActionExecuting(context);
    }
