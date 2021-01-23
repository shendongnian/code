            #region Login Command
    
            public ViewModelCommand LoginCommand { get; set; }
    
            public void Login(object parameter)
            {
                Code.Session.Session.Sesion.Logged = true;
            }
    
            public bool CanLogin(object parameter)
            {
                return !Code.Session.Session.Sesion.Logged;
            }
            #endregion
    
    
    
            #region Logout Command
    
            public ViewModelCommand LogoutCommand { get; set; }
    
            public void Logout(object parameter)
            {
                Code.Session.Session.Sesion.Logged = false;
            }
    
            public bool CanLogout(object parameter)
            {
                return Code.Session.Session.Sesion.Logged;
            }
            #endregion
