    global.asax:
    
    <%@ Application Language="C#" Inherits="GlobalAsax" %>
    
    global.asax.cs (in your App_Code folder):
    
    using System;
    using System.Web;
    
    public class GlobalAsax : HttpApplication
    {
        // you may have lots of other code here
        void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
        }
    }
