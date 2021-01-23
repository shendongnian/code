    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        bool Authenticated = false;
        Authenticated = Membership.ValidateUser(Login1.UserName, Login1.Password) &&
                    
        if (Authenticated)
        {
            MembershipUser user = Membership.GetUser(Login1.UserName);
            Guid i = (Guid)user.ProviderUserKey; //CurrentUser is null
            if (UsefulStaticMethods.CheckIfUserISbanned(i))
            {
                Server.Transfer("~/Banned.aspx");
            }
        }
   
        e.Authenticated = Authenticated;
    }
