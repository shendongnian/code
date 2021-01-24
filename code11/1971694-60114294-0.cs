    namespace ContentManagementSystem  
    {  
        public class RouteConfig  
        {  
            public static void RegisterRoutes(RouteCollection routes)  
            {  
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");  
    
                routes.MapRoute("other_route", "other_route/",
                   defaults: new { controller = "OtherController", action = "OtherAction" });
    
                routes.MapRoute(  
                    name: "Default",  
                    url: "{controller}/{action}/{id}",  
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional } // I already have this working fine  
    
    defaults: new { controller = "Dashbaord", action = "_Index", id = UrlParameter.Optional  // I want to have seperate, but unique route for this controller for actionResult  
    
                );  
    
    
            }  
        }  
    }
