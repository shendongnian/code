    protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
    {
        if (Context.User != null)
        {
            var identity = Context.User.Identity;
            // define our own IIdentity and IPrincipal for an authenticated user
            if (identity.IsAuthenticated)
            {
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                // get the roles from somewhere
                var roles = GetRoles(); 
                identity = new CustomIdentity(ticket.Name);
                IPrincipal principal = new CustomPrincipal(identity, roles);
                Context.User = Thread.CurrentPrincipal = principal;
            }
        }
    }
