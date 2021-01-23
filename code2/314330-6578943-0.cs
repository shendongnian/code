    public void Init(HttpApplication TheApp)
    {
        TheApp.BeginRequest += Application_BeginRequest;
        // End Request handler
        //application.EndRequest += Application_EndRequest;
    }
    
    private void Application_BeginRequest(Object source, EventArgs e) 
    {
      // do something
    }
