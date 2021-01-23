    /// <summary>
    /// Summary description for Module
    /// </summary>
    public class Module : IHttpModule
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }
    
        private void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            String ip = context.Request.UserHostAddress;
            //... code to log IP address
        }
    }
