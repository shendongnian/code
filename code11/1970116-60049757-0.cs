    string SiteURL = @"https://xxx.sharepoint.com/sites/lee/";
    
                var login = "user@xxx.onmicrosoft.com";
                var password = "Password";
    
                var securePassword = new SecureString();
    
                foreach (char c in password)
                {
                    securePassword.AppendChar(c);
                }
                SharePointOnlineCredentials onlineCredentials = new SharePointOnlineCredentials(login, securePassword);
    
                using (var context = new ClientContext(SiteURL))
                {
                    context.Credentials = onlineCredentials;
                    Web site = context.Web;
    
                    //Get the required RootFolder
                    string barRootFolderRelativeUrl = "/sites/lee/LibDS/Folder";
                    Folder barFolder = site.GetFolderByServerRelativeUrl(barRootFolderRelativeUrl);
    
                    //Create new subFolder to load files into
                    string newFolderName = "SPTest";
                    barFolder.Folders.Add(newFolderName);
                    //barFolder.Update();
                    context.ExecuteQuery();
    
                    //Add file to new Folder
                    Folder currentRunFolder = site.GetFolderByServerRelativeUrl(barRootFolderRelativeUrl + "/" + newFolderName);
                    string sharePointDocPath = @"C:\Lee\test.docx";//System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.ToString(), "Sharepoint.xml");
    
                    FileCreationInformation newFile = new FileCreationInformation { Content = System.IO.File.ReadAllBytes(sharePointDocPath), Url = Path.GetFileName(sharePointDocPath), Overwrite = true };
                    var uploadedFile=currentRunFolder.Files.Add(newFile);
                    //currentRunFolder.Update();
                    context.Load(uploadedFile);
                    context.ExecuteQuery();
    
                    //update
                    var item = uploadedFile.ListItemAllFields;
                    item["Title"] = "Updated Title";
                    item.Update();
                    context.ExecuteQuery();
                    Console.WriteLine("---------");
                }
