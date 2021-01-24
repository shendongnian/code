    using System;
    using System.Security;
    using Microsoft.SharePoint.Client;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string siteUrl = "https://tenant.sharepoint.com";
                string userName = "xxx@tenant.onmicrosoft.com";
                string password = "xxx";
                string listName = "listname";
    
                var securePassword = new SecureString();
                foreach (char c in password)
                {
                    securePassword.AppendChar(c);
                }
    
                var credentials = new SharePointOnlineCredentials(userName, securePassword);
                var ctx = new ClientContext(siteUrl);
                ctx.Credentials = credentials;
                var list = ctx.Web.Lists.GetByTitle(listName);
                ctx.Load(list);
                ctx.ExecuteQuery();
                
                using (var wc = new System.Net.WebClient())
                {
                    wc.Credentials = credentials;
                    wc.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
                    wc.Headers["User-Agent"] = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; MDDC)";
                    var pageHtml = wc.DownloadString(siteUrl + "/_layouts/15/listedit.aspx?List={" + list.Id.ToString() + "}");
                    Console.WriteLine(pageHtml);
                }          
                Console.ReadKey();
            }
        }
    }
