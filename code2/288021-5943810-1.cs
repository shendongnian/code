    public class MyCustomApplication : IMvcApplication
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // Your route registrations here
        }
        
        // Other startup operations
    }
