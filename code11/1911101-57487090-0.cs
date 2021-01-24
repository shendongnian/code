                string[] scopes = { "user.read" };
                UserProfile profile = null;
                string authority = "https://login.microsoftonline.com/<tenant>/oauth2/v2.0/token";
                string appKey="you client secret"
    			string clientId=""
    			string redirectUri=""
			
            // We will use MSAL.NET to get a token to call the API On Behalf Of the current user
            try
            {
                // Creating a ConfidentialClientApplication using the Build pattern (https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/wiki/Client-Applications)
                var app = ConfidentialClientApplicationBuilder.Create(clientId)
                   .WithAuthority(authority)
                   .WithClientSecret(appKey)
                   .WithRedirectUri(redirectUri)
                   .Build();
               
                UserAssertion userAssertion = new UserAssertion(bootstrapContext.Token, "urn:ietf:params:oauth:grant-type:jwt-bearer");
                // Acquiring an AuthenticationResult for the scope user.read, impersonating the user represented by userAssertion, using the OBO flow
                AuthenticationResult result = await app.AcquireTokenOnBehalfOf(scopes, userAssertion)
                    .ExecuteAsync();
                string accessToken = result.AccessToken;
                if (accessToken == null)
                {
                    throw new Exception("Access Token could not be acquired.");
                }
                // Call the Graph API and retrieve the user's profile.
                string requestUrl = "";
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                HttpResponseMessage response = await client.SendAsync(request);
                // Return the user's profile.
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    profile = JsonConvert.DeserializeObject<UserProfile>(responseString);
                    return (profile);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
