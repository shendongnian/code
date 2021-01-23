      protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
                if (User.Identity.IsAuthenticated)
                {
                    //add your ckeck here
    
                     if (Usernames.Contains(User.Identity.Name))
                        {
                           Session.Abandon();
                           FormsAuthentication.SignOut();
                        }
                }       
        }
