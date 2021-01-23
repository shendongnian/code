    Application_OnAuthenticateReuqest(object sender, EventArgs e)
    {
      if(!UserHasAccess())
      {
         FormsAuthentication.SignOut();
      }
    }
    
    private bool UserHasAccess()
    {
       var user = Membership.GetUser(Context.User.Identity);
    
       return user.isApproved;
    }
