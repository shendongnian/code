    using System;
    using System.Net.Http;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    
    namespace ConsoleApp3
    {
        class Program
        {
            static void Main(string[] args)
            {
                string _authString = "https://login.microsoftonline.com/xxxxxx.onmicrosoft.com";
                string _clientId = "<client-id>";
                string _clientSecret = "<client-secret>";
                AuthenticationContext authenticationContext = new AuthenticationContext(_authString, false);
                ClientCredential clientCred = new ClientCredential(_clientId, _clientSecret);
                AuthenticationResult authenticationResult;
                authenticationResult = authenticationContext.AcquireTokenAsync("https://graph.microsoft.com", clientCred).GetAwaiter().GetResult();
                Console.WriteLine(authenticationResult.AccessToken);
    
                var token = authenticationResult.AccessToken;
    
                var client = new HttpClient();
                var uri = "https://graph.microsoft.com/v1.0/users";
    
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Clear();
                //GET Method  
                HttpResponseMessage response = client.GetAsync(uri).GetAwaiter().GetResult();
                Console.WriteLine(response.Content.ReadAsStringAsync().Result.ToString());
            }
        }
    }
