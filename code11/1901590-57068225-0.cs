    //install Active Directory Authentication Library (ADAL) and Azure Active Directory Graph Client Library
        public static ActiveDirectoryClient GetActiveDirectoryClientAsApplication()
            {
                Uri servicePointUri = new Uri(ResourceId);
                Uri serviceRoot = new Uri(servicePointUri,tenant);
                ActiveDirectoryClient activeDirectoryClient = new ActiveDirectoryClient(serviceRoot,
                    async () => await AcquireTokenAsyncForApplication());
                return activeDirectoryClient;
            }
    
            public static async Task<string> AcquireTokenAsyncForApplication()
            {
                return await GetTokenForApplication();
            }
    
            /// <summary>
            /// Get Token for Application.
            /// </summary>
            /// <returns>Token for application.</returns>
            public static async Task<string> GetTokenForApplication()
            {
               
                    AuthenticationContext authenticationContext = new AuthenticationContext(
                        authority,
                        false);
    
                    // Configuration for OAuth client credentials 
                   
                    
                        ClientCredential clientCred = new ClientCredential(
                            clientId,
                            cred);
                        AuthenticationResult authenticationResult =
                            await authenticationContext.AcquireTokenAsync(ResourceId, clientCred);
                       var TokenForApplication = authenticationResult.AccessToken;
                    
                
                return TokenForApplication;
            }
    
            public async Task<object> Getuser()
            {
    
                ActiveDirectoryClient client = GetActiveDirectoryClientAsApplication();
                var userLookupTask = client.Users.Where(
             user => user.UserPrincipalName.Equals(
            "", StringComparison.CurrentCultureIgnoreCase)).ExecuteSingleAsync();
                User result =(User) await userLookupTask;
                return result;
    
            }
    
            public async Task Adduser() {
                ActiveDirectoryClient client = GetActiveDirectoryClientAsApplication();
                var newUser = new User()
                {
                    // Required settings
                    DisplayName = "",
                    UserPrincipalName = "",
                    PasswordProfile = new PasswordProfile()
                    {
                        Password = "H@ckMeNow!",
                        ForceChangePasswordNextLogin = false
                    },
                    MailNickname = "",
                    AccountEnabled = true,
    
                    // Some (not all) optional settings
                    GivenName = "",
                    Surname = "",
                    JobTitle = "",
                    Department = "",
                    City = "",
                    State = "",
                    Mobile = "",
                };
    
                await client.Users.AddUserAsync(newUser);
    
            }
