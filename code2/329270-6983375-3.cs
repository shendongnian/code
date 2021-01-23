    using System;
    using System.Web.Routing; 
    namespace WebFormsExtension 
    {
    	public class Global : System.Web.HttpApplication
    	{
    
    		void Application_Start(object sender, EventArgs e)
    		{
    			RegisterRoutes(RouteTable.Routes);
    		}
    
    		public static void RegisterRoutes(RouteCollection routes) 
    		{
    			routes.MapCustomRoute("SampleRoute/{name}"); 
    		}
    
    	}
    
    	public static class MyRouteCollectionExtensions
    	{
    		public static void MapCustomRoute(this RouteCollection routes, string url)
    		{
    			PageRouteHandler handler = new PageRouteHandler("~/default.aspx");
		        Route myRoute = new Route(url, handler);	
		        routes.Add(myRoute);
    		}
    	}
    }
