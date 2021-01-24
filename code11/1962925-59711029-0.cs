    return RedirectToAction("Login", "Account", new {username=account.username});
 2. To fetch the username from FormsAuthentication ticket
    HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
    if (authCookie != null)
    {
        // Get the forms authentication ticket.
        FormsAuthenticationTicket authTicket = 
        FormsAuthentication.Decrypt(authCookie.Value);
        var identity = new GenericIdentity(authTicket.Name, "Forms");
        var principal = new MyPrincipal(identity);
        // Get the custom user data encrypted in the ticket.
        string userData = ((FormsIdentity)(Context.User.Identity)).Ticket.UserData;
        // Deserialize the json data and set it on the custom principal.
        var serializer = new JavaScriptSerializer();
        principal.User = (User)serializer.Deserialize(userData, typeof(User));
        // Set the context user.
        Context.User = principal;
    }
