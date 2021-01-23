    public class LogOnViewModel : ViewModelBase
    {
        private SHAServiceClient WS;
        public LogOnViewModel()
        {
           WS = new SHAServiceClient();
           WS.UserLoginCompleted += new EventHandler<UserLoginCompletedEventArgs>(WS_UserLoginCompleted);
           LoginCommand = new RelayCommand(UserLogin);
        }
        private int userId;
        public int UserId
        {
           get { return userId; }
           set
           {
              userId = value;
              RaisePropertyChanged(()=>UserId);
           }
        }
        private int password;
        public int Password
        {
           get { return password; }
           set
           {
              password = value;
              RaisePropertyChanged(()=>Password);
           }
        }
        private int username;
        public int Username
        {
           get { return username; }
           set
           {
              username = value;
              RaisePropertyChanged(()=>Username);
           }
        }
        private int loginErrorMessage;
        public int LoginErrorMessage
        {
           get { return loginErrorMessage; }
           set
           {
              loginErrorMessage = value;
              RaisePropertyChanged(()=>LoginErrorMessage);
           }
        }
        void WS_UserLoginCompleted(object sender, UserLoginCompletedEventArgs e)
        {
           if (e.Error == null)
           {
              this.UserId = e.Result;
              // send a message to indicate that the login operation has completed
              Messenger.Default.Send(new LoginCompleteMessage());
           }
        }
        public RelayCommand LoginCommand {get; private set;}
        void UserLogin()
        {
           WS.UserLoginAsync(email, password);
        }
    }
