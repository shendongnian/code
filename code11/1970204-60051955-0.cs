    string siteUrl = "https://tenant.sharepoint.com/sites/team";
    string userName = "admin@tenant.onmicrosoft.com";
    string password = "xxxx";
    
    
    var securePassword = new SecureString();
    foreach (char c in password)
    {
    	securePassword.AppendChar(c);
    }
    
    var credentials = new SharePointOnlineCredentials(userName, securePassword);
    var ctx = new ClientContext(siteUrl);
    ctx.Credentials = credentials;
    Web site = ctx.Web;
    
    //Get the required RootFolder
    string barRootFolderRelativeUrl = "Shared%20Documents/Demo";
    Folder barFolder = site.GetFolderByServerRelativeUrl(barRootFolderRelativeUrl);
    
    //Create new subFolder to load files into
    string newFolderName = "SPTest";
    barFolder.Folders.Add(newFolderName);
    barFolder.Update();
    
    //Add file to new Folder
    Folder currentRunFolder = site.GetFolderByServerRelativeUrl(barRootFolderRelativeUrl + "/" + newFolderName);
    string sharePointDocPath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.ToString(), "Sharepoint.xml");
    
    FileCreationInformation newFile = new FileCreationInformation { Content = System.IO.File.ReadAllBytes(sharePointDocPath), Url = Path.GetFileName(sharePointDocPath), Overwrite = true };
    currentRunFolder.Files.Add(newFile);
    currentRunFolder.Update();
    ctx.ExecuteQuery(); 
