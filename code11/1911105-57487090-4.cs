    using Microsoft.Identity.Client;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Runtime.Remoting;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace TestADV2._0
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                string[] scopes = { "user.read" };
                string accesstoken = " ";
                string authority = "https://login.microsoftonline.com/<your tenat name>/oauth2/v2.0/token";
                string appKey = "";
                string clientId = "";
                // get access token with on behalf of flow
                var app = ConfidentialClientApplicationBuilder.Create(clientId)
                  .WithAuthority(authority)
                  .WithClientSecret(appKey)
                  .Build();
                UserAssertion userAssertion = new UserAssertion(accesstoken, "urn:ietf:params:oauth:grant-type:jwt-bearer");
                var result = app.AcquireTokenOnBehalfOf(scopes, userAssertion).ExecuteAsync().Result;
    
                // call Graph API
                
            
        }
    }
