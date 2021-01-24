        public class GraphAuthProvider
    {
        public async Task<GraphServiceClient> AuthenticateViaAppIdAndSecret(
            string tenantId,
            string clientId, 
            string clientSecret)
        {
            var scopes = new string[] { "https://graph.microsoft.com/.default" };
            // Configure the MSAL client as a confidential client
            var confidentialClient = ConfidentialClientApplicationBuilder
                .Create(clientId)
                .WithAuthority($"https://login.microsoftonline.com/{tenantId}/v2.0")
                .WithClientSecret(clientSecret)
                .Build();
            // Build the Microsoft Graph client. As the authentication provider, set an async lambda
            // which uses the MSAL client to obtain an app-only access token to Microsoft Graph,
            // and inserts this access token in the Authorization header of each API request. 
            GraphServiceClient graphServiceClient =
                new GraphServiceClient(new DelegateAuthenticationProvider(async (requestMessage) =>
                {
                    // Retrieve an access token for Microsoft Graph (gets a fresh token if needed).
                    var authResult = await confidentialClient
                        .AcquireTokenForClient(scopes)
                        .ExecuteAsync();
                    // Add the access token in the Authorization header of the API request.
                    requestMessage.Headers.Authorization =
                        new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
                })
            );
            return graphServiceClient;
        }
    }
