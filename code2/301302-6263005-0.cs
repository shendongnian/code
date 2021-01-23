    public class RegisterUser : IRegisterUserView
    {
       bool IRegisterUserView.PasswordEnabled
       {
         get { return tbPassword.Visible ; }
         set { tbPassword.Visible = value; }
       }
    }
