    public class LogoutModule: IHttpModule
    {
        #region IHttpModule Members
        void IHttpModule.Dispose() { }
        void IHttpModule.Init(HttpApplication context)
        {
            context.AuthenticateRequest += new EventHandler(context_AuthenticateRequest);
        }
        #endregion
        /// <summary>
        /// Handle the authentication request and force logouts according to web.config
        /// </summary>
        /// <remarks>See "How To Implement IPrincipal" in MSDN</remarks>
        private void context_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpApplication a = (HttpApplication)sender;
            HttpContext context = a.Context;
            // Extract the forms authentication cookie
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = context.Request.Cookies[cookieName];
            DateTime? logoutTime = ConfigurationManager.AppSettings["forcedLogout"] as DateTime?;
            if (authCookie != null && logoutTime != null && authCookie.Expires < logoutTime.Value)
            {
                // Delete the auth cookie and let them start over.
                authCookie.Expires = DateTime.Now.AddDays(-1);
                context.Response.Cookies.Add(authCookie);
                context.Response.Redirect(FormsAuthentication.LoginUrl);
                context.Response.End();
            }
        }
    }
