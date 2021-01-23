    void Application_BeginRequest(object sender, EventArgs e)
    {
        HttpContext.Current.Response.StatusCode = 403;
        var httpApplication = sender as HttpApplication;
        httpApplication.CompleteRequest();
    }
