    var ticket = new FormsAuthenticationTicket(
        1,
        user.UserID,
        DateTime.Now,
        DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes),
        false,
        "user,user1",
        FormsAuthentication.FormsCookiePath
    );
    var encryptedTicket = FormsAuthentication.Encrypt(ticket);
    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
    {
        Secure = FormsAuthentication.RequireSSL,
        Path = FormsAuthentication.FormsCookiePath,
        Domain = FormsAuthentication.CookieDomain
    };
    Response.AppendCookie(cookie);
