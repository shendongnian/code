    if (Membership.ValidateUser(sUserName, sPw))
    {
    
        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1,
                sUserName,
                DateTime.Now,
                DateTime.Now.AddMinutes(30),
                false,
                FormsAuthentication.FormsCookiePath);
    
        // Encrypt the cookie 
        string hash = FormsAuthentication.Encrypt(ticket);
        HttpCookie cookie = new HttpCookie(
            FormsAuthentication.FormsCookieName, // Name of authentication cookie
            hash); // Hashed ticket
    
        // Set the cookie's expiration time to the tickets expiration time
        if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;
    
        // Add the cookie to the list for outgoing response
        Response.Cookies.Add(cookie);
    }
