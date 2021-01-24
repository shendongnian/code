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
                IPublicClientApplication publicClientApplication = PublicClientApplicationBuilder
                    .Create("cbc3***-ac27-4532-802d-303998a6e712")
                    .Build();
    
                InteractiveAuthenticationProvider authenticationProvider = new InteractiveAuthenticationProvider(publicClientApplication,scopes);
    
                GraphServiceClient graphClient = new GraphServiceClient(authenticationProvider);
                User me = graphClient.Me.Request()
                                    .GetAsync().Result;
                    Console.Write(me.DisplayName);
            }
    
        }
    }
