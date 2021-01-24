    class LoginViewModel : ViewModelBase
    {
        string userName;
        string password;
       
        public string UserName 
        {
             get {return userName;}
            set 
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
         }
    
        public string Password 
        {
            get{return password;}
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        #endregion
    
        #region ctor
        public LoginViewModel()
        {
            //Add Commands
            Commands.Add("Login", new Command(CmdLogin));
        }
        #endregion
    
    
        #region UI methods
    
        private void CmdLogin()
        {
            // do your login jobs here
        }
        #endregion
    }
