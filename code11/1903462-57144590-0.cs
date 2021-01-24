    using System;
    using System.Threading.Tasks;
    using Microsoft.Azure.ActiveDirectory.GraphClient;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    
    namespace ConsoleApp13
        {
            class Program
            {
                static void Main(string[] args)
                {
                    Uri servicePointUri = new Uri("https://graph.windows.net");
                    Uri serviceRoot = new Uri(servicePointUri, "{tenant}");  
                    var aadClient = new ActiveDirectoryClient(
                                    serviceRoot,
                                     getToken);
        
                    var a = aadClient.ServicePrincipals.GetByObjectId("{objectId}").AppRoleAssignedTo.ExecuteAsync().Result;
                    Console.WriteLine(a.CurrentPage.Count);
                    
                }
        
                public static async Task<string> getToken()
                {
                    var context = new AuthenticationContext($"https://login.microsoftonline.com/{tenant}", false);
                    return context.AcquireTokenAsync("https://graph.windows.net", new ClientCredential("{client_id}", "{client_secret}")).Result.AccessToken;
                }
            }
        }
