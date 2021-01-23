    public class Global : HttpApplication
    {   
        protected virtual void Application_BeginRequest(object sender, EventArgs e)
        {
            if (!his.User.Identity.IsAuthenticated)
                this.Response.Redirect("Timeout.aspx");
        }    
    }
