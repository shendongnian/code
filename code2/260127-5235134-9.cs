     protected void LoginButton_Click(object sender, EventArgs e)
        {
         // Validate the user against the Membership framework user store
        if (Membership.ValidateUser(myLogin.UserName, myLogin.Password))
         {
         // Username/password are valid, check email
         MembershipUser currentUser = Membership.GetUser(myLogin.UserName);
        
            if (currentUser != null)
            {
              	if (admin_flag == true)
        	      {
        		         FormsAuthentication.RedirectFromLoginPage(UserName.Text, RememberMe.Checked);
              	}
               else
        	      {
        	      // If we reach here, the user's credentials were invalid -> your access is denied message
         	     InvalidCredentialsMessage.Visible = true;
              	}
            }
          }
          //if code goes here validation of user failed        
        }
