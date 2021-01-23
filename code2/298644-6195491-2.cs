    using(var m = new Mutex("OAuthToken"))
    {
        m.WaitOne();
    
        try
        {
            var token = _tokenService.GetCurrentToken(); 
            var newToken = oauth.RenewAccessToken(token); 
            _tokenService.UpdateCurrentToken(newToken);
        }
        finally
        {
            m.ReleaseMutex();
        }
    }
