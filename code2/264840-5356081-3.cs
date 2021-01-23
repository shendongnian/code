    protected void Application_Init(){
        if (Context.Request.Url.Contains("xyz.com"))
        {
           Response.StatusCode = 301;
           Response.RedirectLocation = url;
           Response.End();
        }
    
    }
