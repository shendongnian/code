    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        Configuration config;
        config = WebConfigurationManager.OpenWebConfiguration("~");
        SessionStateSection SessionState = config.GetSection("system.web/sessionState") as SessionStateSection;
        
        if (SessionState != null)
        {
        SessionState.Mode = System.Web.SessionState.SessionStateMode.InProc;
        //SessionState.Mode = (SessionStateSection)"Mode=InProc";
        //(SessionStateSection)"Inproc";
        config.Save();
        }
    }
