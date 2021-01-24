    var roles = user.Roles.Select(c => c.Nome);
    var ticket = new FormsAuthenticationTicket(
        1,
        user.Id.ToString(),
        DateTime.Now,
        DateTime.Now.AddDays(5),
        model.RememberMe,
        string.Join(",", roles), //or you can serialize complex class as json or whatever
        FormsAuthentication.FormsCookiePath
    );
