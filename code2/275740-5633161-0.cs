    var authTicket = new FormsAuthenticationTicket(
        2,
        username,
        DateTime.Now,
        DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes),
        false,
        "some token that will be used to access the web service"
    );
    var authCookie = new HttpCookie(
        FormsAuthentication.FormsCookieName, 
        FormsAuthentication.Encrypt(authTicket)
    )
    {
        HttpOnly = true
    };
    Response.AppendCookie(authCookie);
