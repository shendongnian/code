    public class MvcApplication : System.Web.HttpApplication
     {
     // Application_Start() and other functions
       protected void Application_BeginRequest()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }
      }
