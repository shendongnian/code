    using Microsoft.SharePoint.Client;
    using System.IO;
    using System.Linq;
    using System.Security;
    
    namespace CSOM
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                using (ClientContext ctx = new ClientContext("https://tenant.sharepoint.com/sites/dev"))
                {
                    string password = "*****";
                    string account = "user@tenant.onmicrosoft.com";
                    var secret = new SecureString();
                    foreach (char c in password)
                    {
                        secret.AppendChar(c);
                    }
                    ctx.Credentials = new SharePointOnlineCredentials(account, secret);
    
                    List mylibrary = ctx.Web.Lists.GetByTitle("Documents");
                    FileCollection files = mylibrary.RootFolder.Folders.GetByUrl("/sites/dev/shared documents/folder1").Files;
    
                    ctx.Load(files);
                    ctx.ExecuteQuery();
    
                    foreach (Microsoft.SharePoint.Client.File file in files)
                    {
                        FileInformation fileinfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(ctx, file.ServerRelativeUrl);
    
                        ctx.ExecuteQuery();
    
                        using (FileStream filestream = new FileStream("D:" + "\\" + file.Name, FileMode.Create))
                        {
                            fileinfo.Stream.CopyTo(filestream);
                        }
                        
                    }
                    files.ToList().ForEach(file => file.DeleteObject());
                    ctx.ExecuteQuery();
                };
    
            }
    
            
        }
    }
