    public class Global : HttpApplication
    {
        protected bool myFlag;
    
        //....
    
        protected internal void Application_BeginRequest(object sender, EventArgs e)
        {
            if (!myFlag) return;
            // ....
        }
    }
