    public static void Uploadfiles(string SiteUrl, string DocLibrary, string ClientSubFolder, string FileName)
            {
               
                string webSPOUrl = "https://testdev.sharepoint.com/sites/test";
                Console.WriteLine("User Name:");
                string userName = "<your username >@testdev.onmicrosoft.com";
                Console.WriteLine("Password:");
                string librayName = "Documents";
    
        
                    try
                    {
                        using (var context = new SP.ClientContext(webSPOUrl))
                        {
                            // Sharepoint Online Authentication
                            context.Credentials = new SP.SharePointOnlineCredentials(userName, password);
                            SP.Web web = context.Web;
        
                            SP.FileCreationInformation newFile = new SP.FileCreationInformation();
                            byte[] FileContent = System.IO.File.ReadAllBytes(FileName);
                            newFile.ContentStream = new System.IO.MemoryStream(FileContent);
                            newFile.Url = Path.GetFileName(FileName);
                            SP.List DocumentLibrary = web.Lists.GetByTitle(DocLibrary);
        
                            SP.Folder Clientfolder = DocumentLibrary.RootFolder.Folders.Add(ClientSubFolder);
        
                            Clientfolder.Update();
                            SP.File uploadFile = Clientfolder.Files.Add(newFile);
        
                            context.Load(DocumentLibrary);
                            context.Load(uploadFile);
                            context.ExecuteQuery();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The File has been uploaded" + Environment.NewLine + "FileUrl -->" + SiteUrl + "/" + DocLibrary + "/" + ClientSubFolder + "/" + Path.GetFileName(FileName));
                         } }
