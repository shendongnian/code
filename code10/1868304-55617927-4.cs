    public void FormsAuthentication_OnAuthenticate(object sender, FormsAuthenticationEventArgs args)
    {
        if (FormsAuthentication.CookiesSupported)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                try
                {
                    //get the forms authentication ticket
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    string userData = authTicket.UserData;
                    //here we suppose userData contains roles joined with ","
                    string[] roles = userData.Split(',');
                    //we have to create identity since it's not created yet
                    var identity = new FormsIdentity(authTicket);
                    var principal = new GenericPrincipal(identity, roles);
                    args.User = principal;
                }
                catch (Exception e)
                {
                    // Decrypt method failed.
                }
            }
        }
        else
        {
            throw new HttpException("Cookieless Forms Authentication is not " +
                                    "supported for this application.");
        }
    }
