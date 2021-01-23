    HttpContext.Current.Response.AppendHeader("Pragma", "no-cache"); 
    HttpContext.Current.Response.AppendHeader("Cache-Control", "no-cache");
    
    HttpContext.Current.Response.CacheControl = "no-cache"; 
    HttpContext.Current.Response.Expires = -1;
    
    HttpContext.Current.response.ExpiresAbsolute = new DateTime(1900, 1, 1); 
    HttpContext.Current.response.Cache.SetCacheability(HttpCacheability.NoCache);
