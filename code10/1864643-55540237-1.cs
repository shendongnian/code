     private async Task<string> GetOnBehalfToken()
        {
            // Get User Assertion
            var authenticateInfo = await HttpContext.Authentication.GetAuthenticateInfoAsync("Bearer");
            string incomingToken = authenticateInfo.Properties.Items[".Token.access_token"];
            UserAssertion userAssertion = new UserAssertion(incomingClientToken, "urn:ietf:params:oauth:grant-type:jwt-bearer");
            string token = string.Empty;
            string authString = string.Format(this.azureAd.AadInstance, this.azureAd.TenantId);
            AuthenticationContext authenticationContext = new AuthenticationContext(authString, false);
            // config for oauth client credentials
            // Use Web app client id and secret key
            ClientCredential clientCredential = new ClientCredential(this.azureAd.ClientId, this.azureAd.AppKey);
            // App ID uri of web api service principal
            var resource = "https://<tenant>.onmicrosoft.com/45854ee0-608a-4dff-xxx-xxxxxxxxxxx";
            AuthenticationResult result = await authenticationContext.AcquireTokenAsync(resource, clientCredential);
            return result.AccessToken;
        }
