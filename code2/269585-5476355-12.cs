    public ActionResult Login(string username, string password)
    {
        // TODO: validate username/password couple and 
        // if they are valid get the roles for the user
        var roles = "RoleA|RoleC";
        var ticket = new FormsAuthenticationTicket(
            1, 
            username,
            DateTime.Now, 
            DateTime.Now.AddMilliseconds(FormsAuthentication.Timeout.TotalMilliseconds), 
            false, 
            roles
        );
        var encryptedTicket = FormsAuthentication.Encrypt(ticket);
        var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
        {
            // IIRC this property is only available in .NET 4.0,
            // so you might need a constant here to match the domain property
            // in the <forms> tag of the web.config
            Domain = FormsAuthentication.CookieDomain,
            HttpOnly = true,
            Secure = FormsAuthentication.RequireSSL,
        };
        Response.AppendCookie(authCookie);
        return RedirectToAction("SomeSecureAction");
    }
