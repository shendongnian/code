     IConfidentialClientApplication confidentialClientApplication = ConfidentialClientApplicationBuilder
                    .Create(clientId)
                    .WithTenantId(tenantID)
                    .WithClientSecret(clientSecret)
                    .Build();
    
     ClientCredentialProvider authProvider = new ClientCredentialProvider(confidentialClientApplication);
    
     GraphServiceClient graphClient = new GraphServiceClient(authProvider);
     var users = await graphClient.Users
                    .Request()
                    .GetAsync();
