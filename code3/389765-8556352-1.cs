        public void CompleteLogin(string sLogin)
        {
            User user = new User();
            user.Login = sLogin;
            ApplicationState.CurrentUser = user;
        }
