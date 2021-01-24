    static async Task<AuthenticationResult> getAccessToken()
    {
        ClientCredential clientCredential = new ClientCredential("YOUR_APP_ID", "YOUR_APP_SECRET");
        AuthenticationContext authContext = new AuthenticationContext("https://login.microsoftonline.com/YOUR_TENANT_ID");
        AuthenticationResult result = null;
    
        try
        {
            result = await authContext.AcquireTokenAsync("https://graph.microsoft.com", clientCredential);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        
        if (result == null)
            Console.WriteLine("Canceling attempt to get access token.");
        else
            Console.WriteLine(result.AccessToken);
    
        return result;
    }
