    protected void Application_OnPostAuthenticateRequest(object sender, EventArgs e)
    {
        HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
        if (authCookie != null)
        {
            //get the forms authentication ticket
            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            string userData = authTicket.UserData;
            //here we suppose userData contains roles joined with ","
            string[] roles = userData.Split(',');
            //at this point we already have Context.User set by forms authentication module
            //we don't change it but add roles
            var principal = new GenericPrincipal(Context.User.Identity, roles);
            // set new principal with roles
            Context.User = principal;
        }
    }
