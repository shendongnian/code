    using System;
    using System.Security;
    using Microsoft.SharePoint.Client;
    
    namespace GetAllSubsites
    {
        class Program
        {
            static void Main(string[] args)
            {
                string userName = "kailash@kailash.cf";
                string siteURL = "https://developer19.sharepoint.com/sites/codesite";
                SecureString password = new SecureString();
                foreach (char c in "pAsSwOrD".ToCharArray())
                    password.AppendChar(c);
    
                using (var clientContext = new ClientContext(siteURL))
                {  
                    clientContext.Credentials = new SharePointOnlineCredentials(userName, password);
    
                    Web web = clientContext.Web;
                    clientContext.Load(web, website => website.Webs);
    
                    clientContext.ExecuteQuery();
                    int b = 0;
                    foreach (Web subWeb in web.Webs)
                    {
                        if (subWeb.Url.Contains(siteURL))
                            b += 1;
                    }
                    Console.WriteLine("Total Number of Subsite is " + b);
                }
                Console.ReadLine();
            }
        }
    }
