    get
    {
        return (System.Web.HttpContext.Current == null) 
            ? System.Web.HttpRuntime.Cache 
            : System.Web.HttpContext.Current.Cache;
    }
