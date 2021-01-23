        private void Application_AuthenticateRequest(Object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = context.Request.Cookies[cookieName];
            if (authCookie == null || string.IsNullOrEmpty(authCookie.Value))
            {
                //... do something
            }
