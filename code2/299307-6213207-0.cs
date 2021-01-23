    protected void Application_BeginRequest(Object sender, EventArgs e)
    {
    	HttpApplication app = (HttpApplication)sender;
    	
    	if(app.Request.ServerVariables["REMOTE_ADDR"] != "1.1.1.1")
    	{
    		HttpContext.Current.Response.End();
    		return
    	}
    }
