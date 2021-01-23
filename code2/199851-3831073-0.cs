    MagNET.AuthenticationService.AuthenticationServiceSoapClient svc =
             new MagNET.AuthenticationService.AuthenticationServiceSoapClient();
        svc.AuthenticateUserCompleted += new EventHandler<AuthenticationService.AuthenticateUserCompletedEventArgs>(svc_AuthenticateUserCompleted);
        string username = txtBoxUsername.Text;
        string password = txtBoxPassword.Password;
        svc.AuthenticateUserAsync(username, password);
