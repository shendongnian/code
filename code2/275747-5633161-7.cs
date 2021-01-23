    [HttpPost]
    public ActionResult LogOn(string username, string password)
    {
        // TODO: verify username/password, obtain token, ...
        // and if everything is OK generate the authentication cookie like this:
    
        var authTicket = new FormsAuthenticationTicket(
            2,
            username,
            DateTime.Now,
            DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes),
            false,
            "some token that will be used to access the web service and that you have fetched"
        );
        var authCookie = new HttpCookie(
            FormsAuthentication.FormsCookieName, 
            FormsAuthentication.Encrypt(authTicket)
        )
        {
            HttpOnly = true
        };
        Response.AppendCookie(authCookie);
        // ... redirect
    }
