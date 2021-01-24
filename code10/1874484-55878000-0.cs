    public class Global : System.Web.HttpApplication
    { ...
        void Application_AcquireRequestState(object sender, EventArgs e)
        {            
            HttpContext context = HttpContext.Current;
            // CheckSession() inlined
            if (context.Session["UserId"] == null)
            {
              context.Response.Redirect("Login.aspx");
            }
        }
      ...
    }
