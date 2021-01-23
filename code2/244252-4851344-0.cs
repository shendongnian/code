    public static void Login(HttpResponse response, string username,
        bool rememberMeChecked)
    {
        DateTime expiration = DateTime.Now.AddMinutes(30);
        if (rememberMe) {
            expiration = DateTime.Now.AddMonths(1);
        }
    
        FormsAuthentication.Initialize();
        FormsAuthenticationTicket tkt = new FormsAuthenticationTicket(1, username,
            DateTime.Now, expiration, rememberMeChecked,
            FormsAuthentication.FormsCookiePath);
    
        HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName,
            FormsAuthentication.Encrypt(tkt));
        ck.Path = FormsAuthentication.FormsCookiePath;
        response.Cookies.Add(ck);
    }
