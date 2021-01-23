     private void FacebookLoginBrowser_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            FacebookAuthenticationResult authResult;
            if (FacebookAuthenticationResult.TryParse(e.Uri, out authResult))
            {
                if (authResult.ErrorReason == "user_denied")
                {
                    // Do something knowing that this failed (cancel).                   }
                else
                {
                    fbApp.Session = authResult.ToSession();
                    loginSucceeded(); 
                }                
            }
        }
