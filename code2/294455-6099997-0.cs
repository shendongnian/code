           void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RegisterRoutes(RouteTable.Routes);
        }
                public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("home",
                "home",
                "~/Home.aspx");
        }
