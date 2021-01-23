    public class MvcApplication : System.Web.HttpApplication
    {
      public static string _defaultAreaKey = "DefaultArea";
     
      public static void RegisterDefaultRoute(RouteCollection routes)
      {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
     
        //reading parameter DefaultArea from web.config 
        string defaultArea = ConfigurationManager.AppSettings[_defaultAreaKey];
     
        //check for null
        if (String.IsNullOrEmpty(defaultArea)) 
          throw new Exception("Default area isn\'t set");
     
        //select routes from registered, 
        //which have DataTokens["area"] == DefaultArea
        //Note, each Area might have more than one route
        var defRoutes = from Route route in routes
                where
                route.DataTokens != null &&
                route.DataTokens["area"] != null && 
                route.DataTokens["area"].ToString() == defaultArea
                select route;
     
     
        //cast to array, for LINQ query will be done,
        //because we will change collection in cycle
        foreach (var route in defRoutes.ToArray())
        {
          //Important! remove from routes' table
          routes.Remove(route);
     
          //crop url to first slash, ("Public/", "Admin/" etc.)
          route.Url = route.Url.Substring(route.Url.IndexOf("/") + 1);
     
          //Important! add to the End of the routes' table
          routes.Add(route);
        }      
      }
     
      protected void Application_Start()
      {
        //register all routes
        AreaRegistration.RegisterAllAreas();
     
        //register default route and move it to end of table
        RegisterDefaultRoute(RouteTable.Routes);      
      }
    }
    
