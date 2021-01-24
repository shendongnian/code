    public void CreateUser_OnClick(object sender, EventArgs args)
    {
      try
      {
        // Create new user.   
        MembershipUser newUser = Membership.CreateUser(UsernameTextbox.Text, PasswordTextbox.Text);
    
    
        // If user created successfully, set password question and answer (if applicable) and 
        // redirect to login page. Otherwise return an error message.    
        if (Membership.RequiresQuestionAndAnswer)
        {
          newUser.ChangePasswordQuestionAndAnswer(PasswordTextbox.Text,
                                                  PasswordQuestionTextbox.Text,
                                                  PasswordAnswerTextbox.Text);
        }
    
        Response.Redirect("login.aspx");
      }
      catch (MembershipCreateUserException e)
      {
        Msg.Text = GetErrorMessage(e.StatusCode);
      }
      catch (HttpException e)
      {
        Msg.Text = e.Message;
      }
    }
    
    public string GetErrorMessage(MembershipCreateStatus status)
    {
       switch (status)
       {
          case MembershipCreateStatus.DuplicateUserName:
            return "Username already exists. Please enter a different user name.";
    
          case MembershipCreateStatus.DuplicateEmail:
            return "A username for that email address already exists. Please enter a different email address.";
    
          case MembershipCreateStatus.InvalidPassword:
            return "The password provided is invalid. Please enter a valid password value.";
    
          case MembershipCreateStatus.InvalidEmail:
            return "The email address provided is invalid. Please check the value and try again.";
    
          case MembershipCreateStatus.InvalidAnswer:
            return "The password retrieval answer provided is invalid. Please check the value and try again.";
    
          case MembershipCreateStatus.InvalidQuestion:
            return "The password retrieval question provided is invalid. Please check the value and try again.";
    
          case MembershipCreateStatus.InvalidUserName:
            return "The user name provided is invalid. Please check the value and try again.";
    
          case MembershipCreateStatus.ProviderError:
            return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
    
          case MembershipCreateStatus.UserRejected:
            return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
    
          default:
            return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
       }
    }
