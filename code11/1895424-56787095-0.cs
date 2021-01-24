    using Microsoft.SharePoint.Client;
    using System;
    using System.Security;
    
        namespace CSOM
        {
            class Program
            {
                static void Main(string[] args)
                {
        
                    string userName = "user@tenant.onmicrosoft.com";
                    string password = "************";
                    var securePassword = new SecureString();
                    foreach (char c in password)
                    {
                        securePassword.AppendChar(c);
                    }
                    using (var clientContext = new ClientContext("https://tenant.sharepoint.com/sites/dev"))
                    {
                        clientContext.Credentials = new SharePointOnlineCredentials(userName, securePassword);
                        Web web = clientContext.Web;
                        clientContext.Load(web, a => a.ServerRelativeUrl);
                        clientContext.ExecuteQuery();
                        Console.WriteLine(web.ServerRelativeUrl);
                    }   
                    
                }
        
                
            }
        }
