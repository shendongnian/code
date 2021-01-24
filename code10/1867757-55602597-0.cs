    public class YourModule : IHttpModule
    {
        public void Init(HttpApplication application)
        {
            application.BeginRequest += Application_BeginRequest;
        }
        private void Application_BeginRequest(object source, EventArgs e)
        {
            var application = (HttpApplication)source;
            var context = application.Context;
            //your code
        }
    }
