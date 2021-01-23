    FormsAuthentication.Initialize();
    // Create a new ticket used for authentication
    FormsAuthentication.SetAuthCookie(UserName.Text, false);
    // Create a new ticket used for authentication
    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
       1, // Ticket version
       UserName.Text, // Username associated with ticket
       DateTime.Now, // Date/time issued
       DateTime.Now.AddMinutes(30), // Date/time to expire
       false, // "true" for a persistent user cookie
       "Admin", // User-data, in this case the roles
       FormsAuthentication.FormsCookiePath);// Path cookie valid for
    
    // Encrypt the cookie using the machine key for secure transport
    string hash = FormsAuthentication.Encrypt(ticket);
    HttpCookie cookie = new HttpCookie(
       FormsAuthentication.FormsCookieName, // Name of auth cookie
       hash); // Hashed ticket
    
    // Set the cookie's expiration time to the tickets expiration time
    if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;
    
    // Add the cookie to the list for outgoing response
    Response.Cookies.Add(cookie);
