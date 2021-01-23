    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
    
            var app = new MyCustomApplication();
            app.RegisterRoutes(RouteTable.Routes);
            // Other startup calls
        }
    }
