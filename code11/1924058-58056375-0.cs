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
    
                using (ClientContext ctx = new ClientContext("https://tenantname.sharepoint.com/sites/sitename/"))
                {
                    string password = "********";
                    string account = "username@tenantname.onmicrosoft.com";
                    var secret = new SecureString();
                    foreach (char c in password)
                    {
                        secret.AppendChar(c);
                    }
                    ctx.Credentials = new SharePointOnlineCredentials(account, secret);
                    ctx.Load(ctx.Web);
                    ctx.ExecuteQuery();
                
                    List list = ctx.Web.Lists.GetByTitle("libraryTitle");
    
                    FileCollection files = list.RootFolder.Folders.GetByUrl("/sites/sitename/shared documents/foldername").Files;
    
                    ctx.Load(files);
                    ctx.ExecuteQuery();
    
                    foreach (Microsoft.SharePoint.Client.File file in files)
                    {
                        FileInformation fileinfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(ctx, file.ServerRelativeUrl);
    
                        ctx.ExecuteQuery();
    
                        using (FileStream filestream = new FileStream("C:" + "\\" + file.Name, FileMode.Create))
                        {
                            fileinfo.Stream.CopyTo(filestream);
                        }
                        
                    }
                };
    
            }
    
            
        }
    }
