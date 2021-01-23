    // this code will mark the forms authentication cookie and the
    // session cookie as Secure.
    if (Response.Cookies.Count > 0)
    {
        foreach (string s in Response.Cookies.AllKeys)
        {
            if (s == FormsAuthentication.FormsCookieName || "asp.net_sessionid".Equals(s, StringComparison.InvariantCultureIgnoreCase))
            {
                 Response.Cookies[s].Secure = true;
            }
        }
    }
