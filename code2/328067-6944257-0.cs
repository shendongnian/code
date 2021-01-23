      protected void Application_Start(object sender, EventArgs e)
        {
            // ROUTING.
            Helper.RegisterRoutes(RouteTable.Routes);
        }
    
    
    public static class Helper
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // Register a route for Categories/All
            routes.MapPageRoute(
                    "All Categories",       // Route name
                    "Categories/All",       // Route URL
                    "~/AllCategories.aspx"   // Web page to handle route
                );
    
            // Register a route for Products/{ProductName}
            routes.MapPageRoute(
                "View Content",             // Route name
                "Content/{ContentId}",   // Route URL
                "~/Cms/FrontEndCms/Content.aspx"        // Web page to handle route
            );
    
    }
