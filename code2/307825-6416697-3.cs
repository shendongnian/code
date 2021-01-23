    bool isAdmin = false;
    HttpCookie authCookie = context.Request.Cookies[cookieName];
    if (authCookie != null)
    {
      FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
      if (authTicket != null)
      {
        isAdmin = Convert.ToBoolean(authTicket.UserData);
      }
    }
