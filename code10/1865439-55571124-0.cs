    protected void Application_BeginRequest (Object sender, EventArgs e) 
    {
        if (Request.Headers.AllKeys.Contains ("Origin") && Request.HttpMethod == "OPTIONS") 
        {
            Context.Response.AddHeader ("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Key, Accept,Authorization,serverName");
            Context.Response.AddHeader ("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
            Context.Response.End ();
        }
    }
