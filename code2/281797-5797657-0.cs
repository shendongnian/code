        var user = new User { UserId = 1, Nickname = "Foo" };
        
        var encodedTicket = FormsAuthentication.Encrypt(
           new FormsAuthenticationTicket(
              1, 
              user.Nickname, 
              DateTime.Now,  
              DateTime.UtcNow.Add(FormsAuthentication.Timeout),
              true,                                                                            
              user.ToString()));
    
    var httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encodedTicket);
    httpResponseBase.Cookies.Add(httpCookie);
