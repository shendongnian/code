    public class LoginFormViewModel 
     {
       public ICommand LoginFormCommand { get; private set; }
       private string _user;
       private string _pass;
       public LoginViewModel()
         {
          LoginFormCommand = new Command(LogUserIn());
         }
       public string User {
        get => _user; 
        set
         {
          if (_userName != value){ _userName = value;}
          OnPropertyChanged();
         }
        }
      public string Pass {
       get => _pass; 
       set
        {
         if (_userName != value){ _userName = value;}
         OnPropertyChanged();
        }
      }
     public LogUserIn()
      {
       bool IamLoggedIn = AFunctionThatCallsAWebService(User, Pass);
      }
     }
