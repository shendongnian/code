    [WebMethod(Description = "Login to start a session")]
    public bool Login(string userName, string password)
    {
        if (!Membership.Provider.ValidateUser(userName, password))
            return false;
        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
               1,
               userName,
               DateTime.Now,
               DateTime.Now.AddMinutes(500),
               false,
               FormsAuthentication.FormsCookiePath);// Path cookie valid for
        // Encrypt the cookie using the machine key for secure transport
        string hash = FormsAuthentication.Encrypt(ticket);
        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, // Name of auth cookie
                                           hash); // Hashed ticket
        // Set the cookie's expiration time to the tickets expiration time
        if (ticket.IsPersistent)
            cookie.Expires = ticket.Expiration;
        // Add the cookie to the list for outgoing response
        if(HttpContext.Current !=null)
            HttpContext.Current.Response.Cookies.Add(cookie);
        FormsAuthentication.SetAuthCookie(userName, true);
        return true;
    }
