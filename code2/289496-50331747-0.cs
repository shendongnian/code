        // this code will mark the forms authentication cookie and the
        // session cookie as Secure.
        if (Request.IsSecureConnection)
        {
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
        }
        else
        {
            //if not secure, then don't set session cookie
            Response.Cookies["asp.net_sessionid"].Value = string.Empty;
            Response.Cookies["asp.net_sessionid"].Expires = new DateTime(2018, 01, 01);
        }
