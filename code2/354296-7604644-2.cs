    protected void Application_BeginRequest()
    {
       MvcMiniProfiler.MiniProfiler.Start();  
    }
    protected void Application_AuthenticateRequest(Object sender, EventArgs e)
    {
       if(!CurrentUserIsAllowedToSeeProfiler())
       {
           MvcMiniProfiler.MiniProfiler.Stop(discardResults: true);
       }
    }
