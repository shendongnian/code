    protected void Application_BeginRequest(object sender, EventArgs e)
    {
            String ipAddress = System.Web.HttpContext.Current.Request.UserHostAddress;
            LogicalThreadContext.Properties["ipAddress"] = ipAddress;
            log.Info("Application_BeginRequest");
    }
    protected void Application_EndRequest(object sender, EventArgs e)
    {
            log.Info("Application_EndRequest");
    }
