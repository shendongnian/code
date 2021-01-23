    protected void Application_BeginRequest()
    {            
        if (IsStaticRequest())
        {
             // do something here
        }
    }
    
    private bool IsStaticRequest()
    {
       var result = Request.Url.AbsolutePath.Split('/');
       if (result.Length < 2) return false;
       return STATIC_CONTENT_PATHS.Contains(result[1]);
    }
