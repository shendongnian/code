    using System;
    using System.Collections.Generic;
    using System.ServiceModel.Activation;
    using System.Web;
    using System.Web.Routing;
    
    public class Global : System.Web.HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteTable.Routes.Add(new ServiceRoute("/", new WebServiceHostFactory(), typeof(TestService)));
        }
    }
