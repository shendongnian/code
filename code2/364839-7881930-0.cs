    bool validated = Membership.ValidateUser(uname, pwd);
    if (validated)
    {
        if (Request.QueryString["ReturnUrl"] != null)
        {
            FormsAuthentication.RedirectFromLoginPage(uname, false);
        }
        else
        {
            FormsAuthentication.SetAuthCookie(uname, false);
        }
        return;
    }
    //Response.Write("Failed to authenticate, invalid credentials.");
