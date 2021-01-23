    FormsAuthenticationTicket tkt;
    string cookiestr;
    HttpCookie ck;
    tkt = new FormsAuthenticationTicket(1, _user.User_Id.ToString(), DateTime.Now,
    DateTime.Now.AddMinutes(60), true, string.Format("{0},{1}",     System.DateTime.Now.ToString(), _user.User_Id.ToString()));
    cookiestr = FormsAuthentication.Encrypt(tkt);
    ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
    ck.Path = FormsAuthentication.FormsCookiePath;
    Response.Cookies.Add(ck);
