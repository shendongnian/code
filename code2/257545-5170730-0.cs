    protected void Application_AuthenticateRequest(Object sender, EventArgs e)
    {
        var user = HttpContext.Current.User;
        if (user == null || !user.Identity.IsAuthenticated)
        {
            return;
        }
        // read the roles from the cookie and set a custom generic principal
        var fi = (FormsIdentity) HttpContext.Current.User.Identity;
        var fat = fi.Ticket;
        var astrRoles = fat.UserData.Split('|');
        HttpContext.Current.User = new GenericPrincipal(fi, astrRoles);
    }
