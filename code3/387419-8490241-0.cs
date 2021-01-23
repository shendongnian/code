    protected void Application_AuthenticateRequest(Object sender, EventArgs e)
    {
        string cookieName = FormsAuthentication.FormsCookieName;
        HttpCookie authCookie = Context.Request.Cookies[cookieName];
        if (authCookie == null)
        {
            return;
        }
        FormsAuthenticationTicket authTicket = null;
        try
        {
            authTicket = FormsAuthentication.Decrypt(authCookie.Value);
        }
        catch
        {
            return;
        }
        if (authTicket == null)
        {
            return;
        }
        string[] roles = authTicket.UserData.Split(new char[] { '|' });
        FormsIdentity id = new FormsIdentity(authTicket);
        GenericPrincipal principal = new GenericPrincipal(id, roles);
       
        Context.User = principal;
    }
