            public static string GetAuthToken()
            {
    
                // TODO Substitute your app registration values that can be obtained after you
                // register the app in Active Directory on the Microsoft Azure portal.
                string clientId = "3oi467rf-2336-4039-b82i-7c5b859c7be0"; // Client ID after app registration
                string userName = "xyz@youOrg.onmicrosoft.com";
                string password = "Password";
                UserCredential cred = new UserCredential(userName, password);
    
                // Authenticate the registered application with Azure Active Directory.
                AuthenticationContext authContext = new AuthenticationContext("https://login.windows.net/common", false);
                AuthenticationResult result = authContext.AcquireToken(serviceUri, clientId, cred);
                return result.AccessToken;
            }
            public static void RetrieveAccounts(string authToken)
            {
                HttpClient httpClient = null;
                httpClient = new HttpClient();
                //Default Request Headers needed to be added in the HttpClient Object
                httpClient.DefaultRequestHeaders.Add("OData-MaxVersion", "4.0");
                httpClient.DefaultRequestHeaders.Add("OData-Version", "4.0");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
                //Set the Authorization header with the Access Token received specifying the Credentials
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
    
                httpClient.BaseAddress = new Uri(redirectUrl);
                var response = httpClient.GetAsync("accounts?$select=name").Result;
                if (response.IsSuccessStatusCode)
                {
                    var accounts = response.Content.ReadAsStringAsync().Result;
                }
            }
