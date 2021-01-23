    namespace Company
    {
        public class LicensedApplication : System.Web.HttpApplication
        {
            void Application_BeginRequest(object sender, EventArgs e)
            {
                // Check license here
            }
        }
    }
