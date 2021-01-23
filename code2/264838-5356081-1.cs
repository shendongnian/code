    protected void Application_BeginRequest(){
        if (Context.Request.Url.Contains("xyz.com"))
        {
           Response.StatusCode = 301;
           Response.RedirectLocation = url;
           Response.End();
        }
    
    }
