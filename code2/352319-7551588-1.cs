    protected void Application_Error()
    {
        bool isAjaxCall = string.Equals("XMLHttpRequest", Context.Request.Headers["x-requested-with"], StringComparison.OrdinalIgnoreCase);
        Context.ClearError();
        if (isAjaxCall)
        {
            Context.Response.ContentType = "application/json";
            Context.Response.StatusCode = 200;
            Context.Response.Write(
                new JavaScriptSerializer().Serialize(
                    new { error = "some nasty error occured" }
                )
            );
        }
    }
