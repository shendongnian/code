    public class MvcApplication : System.Web.HttpApplication
    {
        public override void Init()
        {
            base.Init();
            this.AuthenticateRequest += new EventHandler(MvcApplication_AuthenticateRequest);
        }
        void MvcApplication_AuthenticateRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                HttpContext.Current.User = GetYourUserAsIPrincipal();
            }
        }        
    }
