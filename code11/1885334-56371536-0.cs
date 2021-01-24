    private static async Task<string> GetToken()
        {
            string authority = "https://login.microsoftonline.com/{tenantId}";
            string resource = "https://graph.microsoft.com";
            string userName = "xxxxxxxxx";
            string password = "xxxxxxx";
            string clientId = "Your Client ID (GUID)";
            
            UserPasswordCredential userPasswordCredential = new UserPasswordCredential(userName, password);
            
            AuthenticationContext authenticationContext = new AuthenticationContext(authority);
            var result = AuthenticationContextIntegratedAuthExtensions.AcquireTokenAsync(authenticationContext, resource, clientId, userPasswordCredential).Result;
            
            return result.AccessToken;            
        }
