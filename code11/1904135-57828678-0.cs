    private bool IsAuthenticated(string username, string pwd)
        {            
            bool authenticated = false;
            try
            {
                //token cache not to set, that is the reason sending the null value
                var authenticationContext = new AuthenticationContext("https://login.microsoftonline.com/{tenant-ID}/oauth2/token", true, null);
                AuthenticationResult authenticationResult = null;
  
                var credential = new UserPasswordCredential(username, pwd);
                authenticationResult = authenticationContext.AcquireTokenAsync("https://tenantname.onmicrosoft.com/ServiceAppId", "ClientAppId", credential).Result;
                
               authenticated = true;
            }           
            catch (Exception ex)
            {
                return false;               
                //not authenticated due to some other exception 
            }
