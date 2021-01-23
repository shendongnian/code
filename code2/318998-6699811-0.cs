    void Authenticate()
    {
        // start webservice here and 
        // show loading 
    }
    void Webservice_Callback()
    {
        // process response
        Deployment.Current.Displatcher.BeginInvoke(AuthenticateCompleted);
    }
    void AuthenticateCompleted()
    {
        // stop loading
        // close popup
    }
