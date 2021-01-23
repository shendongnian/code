    using System.Web;
        
    //......
    //......
    //......
        
    if (someCondition) 
    {
    HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.Public); //Location="Any"
    HttpContext.Current.Response.Cache.SetExpires(DateTime.Now.AddSeconds(1800)); //Duration="1800"
    HttpContext.Current.Response.Cache.SetValidUntilExpires(true); 
    }
 
