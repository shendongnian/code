    private void ApplicationStart(object sender, StartupEventArgs e)
        {
            iwndwMain = new MainWindow();
            WindowInitiations();
        }
    public bool ShouldMoveOn {get;set;}
        private void WindowInitiations()
        {
            LoginProcess();
            MainWindowProcess();
        }
        private void LoginProcess()
        {
            var vmLogOn = new VMLogon(); //LogOn ViewModel
            try
            {
                LoginResult = SingletonData.Instance.GlobalDialogSerivce.ShowDialog(vmLogOn);
                ShouldMoveOn = vmLogOn.MoveOn;
                //SingletonData.Instance.GlobalUserSessionData = vmLogOn.UserSessionData; //Only when this data is filled, we can initiate the VMTimeSheet
            }
            catch (Exception)
            {
                string message = @"Unable to start the application. If this is a server issue, please try after sometime or try contacting the admin";
                VMConfirmationWindow vmconf = new VMConfirmationWindow(message);
                SingletonData.Instance.GlobalDialogSerivce.ShowDialog(vmconf);
            }
        }
        private void MainWindowProcess()
        {
            if (ShouldMoveOn) //Log In is Success
            {
                iwndwMain.ShowDialog();
                if (VMMain.Instance.ViewModelLogOn.IsLoggedOut == true)
                {
                    
                    WindowInitiations();
                }
                else
                {
                    Application.Current.Shutdown();
                }
            }
            else
            {
                Application.Current.Shutdown();
            }
        }
    }
