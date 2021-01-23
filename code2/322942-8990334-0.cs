    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var config = new WebApiConfiguration() { EnableTestClient = true };
            RouteTable.Routes.MapServiceRoute<HelloWorldApi>("api", config);
        }
    }
