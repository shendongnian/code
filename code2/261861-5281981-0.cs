    // this event occurs just after user is authenticated
    void Application_PostAuthenticateRequest(object sender, EventArgs e)
    {
        // checking if request is not for ChangePassword.aspx page, as it should not be redirected
        if (User.Identity.IsAuthenticated
            && !Context.Request.Url.AbsoluteUri.ToLower().Contains("/changepassword.aspx"))
        {
            Context.Response.Redirect("~/ChangePassword.aspx");
        }
    }
