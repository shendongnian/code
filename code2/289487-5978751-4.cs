    // this code will mark the forms authentication cookie and the
    // session cookie as Secure.
    if (Response.Cookies.Count > 0)
    {
        foreach (string s in Response.Cookies.AllKeys)
        {
            if (s == FormsAuthentication.FormsCookieName || s.ToLower() == "asp.net_sessionid")
            {
                 Response.Cookies[s].Secure = true;
            }
        }
    }
