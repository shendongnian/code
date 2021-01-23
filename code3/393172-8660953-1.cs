        string CookieName = "Website Authentication";
        string vReturn = null;
        HttpCookie vCookie = null;
        if(HttpContext.Current.Request.Cookies.AllKeys.Any(t => t == CookieName))
            vCookie = HttpContext.Current.Request.Cookies[CookieName];
        if(vCookie != null)
            vReturn = FormsAuthentication.Decrypt(vCookie.Value).Name;
        return vReturn;
