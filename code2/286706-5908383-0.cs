    public static string MappedApplicationPath
    {
       get
       {
          string APP_PATH = System.Web.HttpContext.Current.Request.ApplicationPath.ToLower();
          if(APP_PATH == "/")      //a site
             APP_PATH = "/";
          else if(!APP_PATH.EndsWith(@"/")) //a virtual
             APP_PATH += @"/";
          string it = System.Web.HttpContext.Current.Server.MapPath(APP_PATH);
          if(!it.EndsWith(@"\"))
             it += @"\";
          return it;
       }
    }
