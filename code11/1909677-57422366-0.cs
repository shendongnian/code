                string[] scopes = { "Mail.Send" };
                string clientId = "";
                IPublicClientApplication publicClientApplication = PublicClientApplicationBuilder
                .Create(clientId)
                .WithRedirectUri("https://localhost")
                .Build();
                
                InteractiveAuthenticationProvider authProvider = new InteractiveAuthenticationProvider(publicClientApplication, scopes);
    
                GraphServiceClient graphClient = new GraphServiceClient(authProvider);
