    protected override void HandleUnauthorizedRequest(AuthorizationContext context)
    {
        if (context.HttpContext.Request.IsAuthenticated)
        {
            context.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Forbidden.cshtml"
            };
        }
        else
        {
            base.HandleUnauthorizedRequest(context);
        }
    }
