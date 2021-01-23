    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        try
        {
            HttpContext.Current.Request.Headers["Accept-Encoding"] = "";
        }
        catch(Exception){}
    }
