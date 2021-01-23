    var ticket = new FormsAuthenticationTicket(
        1,
        user.UserID,
        DateTime.Now,
        DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes),
        false,
        "user,user1",
        FormsAuthentication.FormsCookiePath
    );
