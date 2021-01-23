    protected override void Initialize(RequestContext context)
    {
        // ...
        if(context.HttpContext != null)
        {
            if(context.HttpContext.Request.Path == "some/restricted/route" 
                && CurrentUser.Role != "Admin")
            {
                // or similar error page
                var url = Url.Action("UnAuthorized", "Error");
                context.HttpContext.Response.Redirect(url);
            }
        }
    }
