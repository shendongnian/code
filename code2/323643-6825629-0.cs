    protected void Application_BeginRequest()
    {            
        if (IsStaticRequest()) FerretLib.Profiler.Start(Request);
    }
    private readonly string[] STATIC_CONTENT_PATHS = new string[] { "css", "js", "img" }; 
    private bool IsStaticRequest()
    {
       var result = Request.Url.AbsolutePath.Split('/');
       if (result.Length < 2) return false;
       return STATIC_CONTENT_PATHS.Contains(result[1]);
    }
