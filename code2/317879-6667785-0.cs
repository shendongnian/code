    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e){
        if (UsefulStaticMethods.CheckIfUserISbanned(Login1.UserName)) {
            e.Authenticated = false;
            Server.Transfer("~/Banned.aspx");
        }else{
           //authenticate...
           e.Authenticated = true;
        }
    }
