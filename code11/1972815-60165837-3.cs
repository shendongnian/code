    using Microsoft.Graph;
    using Microsoft.Graph.Auth;
    using Microsoft.Identity.Client;
    using System;
    
    namespace AzureTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] scopes = { "https://graph.microsoft.com/.default" };
                IConfidentialClientApplication confidentialClientApplication = ConfidentialClientApplicationBuilder
                    .Create("")
                    .WithRedirectUri("")
                    .WithClientSecret("") 
                    .Build();
            }
        }
    }
