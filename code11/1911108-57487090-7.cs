    string[] scopes = { "user.read" };
                string accesstoken = "";
               
                string appKey = "yor web api client secret";
                string clientId = "your web api application id";
    
                var app = ConfidentialClientApplicationBuilder.Create(clientId)
                  .WithClientSecret(appKey)
                  .Build();
                UserAssertion userAssertion = new UserAssertion(accesstoken, 
     "urn:ietf:params:oauth:grant-type:jwt-bearer");
                var result = app.AcquireTokenOnBehalfOf(scopes, userAssertion).ExecuteAsync().Result;
                Console.WriteLine(result.AccessToken);
