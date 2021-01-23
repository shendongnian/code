    protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
    {
        try
        {
           e.Authenticated = myMembershipProvider.ValidateUser(LoginControl1.UserName,LoginControl.Password);
        }
        catch(Exception ex)
        {
          LoginControl1.FailrureText = ex.Message;
        }
    }
