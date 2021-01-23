    private void OnAuthenticate(object sender, AuthenticateEventArgs e) {
        bool authenticated = false;
        String encryptedPassword = Encrypt(Login1.Password);
        authenticated = YourAuthenticationMethod(Login1.UserName, encryptedPassword );
        e.Authenticated = authenticated;
    }
    private bool YourAuthenticationMethod(String username, String encryptedPassword) {
        //test the encrypted password against that retrieved from your database using the username
    }
