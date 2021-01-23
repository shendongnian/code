    void Application_BeginRequest(object sender, EventArgs e)
    {
        if(!getValidator.Validate(HttpContext.Current.Request))
        {
            HttpContext.Current.Response.StatusCode = 403 
            var httpApplication = sender as HttpApplication;
            httpApplication.CompleteRequest();
        }
    }
