    using System;
    using System.Security;
    using Microsoft.SharePoint.Client;
    using System.Net;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string userName = "admin@tenant.onmicrosoft.com";
                string password = "xxx";
                
                string apiUrl = "https://tenant.sharepoint.com/_api/search/query?querytext='docName'";
                var securePassword = new SecureString();
                foreach (char c in password.ToCharArray()) securePassword.AppendChar(c);
                var credential = new SharePointOnlineCredentials(userName, securePassword);
                Uri uri = new Uri(apiUrl);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = "GET";
                request.Credentials = credential;
                request.Headers[HttpRequestHeader.Cookie] = credential.GetAuthenticationCookie(new Uri(apiUrl), true);  // SPO requires cookie authentication
                request.Headers["X-FORMS_BASED_AUTH_ACCEPTED"] = "f";
    
                HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
                Stream webStream = webResponse.GetResponseStream();
                StreamReader responseReader = new StreamReader(webStream);
                string response = responseReader.ReadToEnd();
                 
            }
        }
    }
