        /*  
              install Microsoft.Graph.Beta
              install Microsoft.Graph.COre
              install Microsoft.Graph.Beta.Auth
            */
            string clientId = "your application id";
            string appKey = "your client secret";
            string tenantId = "your tenant id";
         IConfidentialClientApplication confidentialClientApplication = 
            ConfidentialClientApplicationBuilder
                    .Create(clientId)
                    .WithTenantId(tenantId)
                    .WithClientSecret(appKey)
                    .Build();
        
                    ClientCredentialProvider authProvider = new 
                    ClientCredentialProvider(confidentialClientApplication);
                    var application = await graphClient.Applications["{id}"]
    	                                    .Request()
    	                                    .GetAsync();
                   
           
