    DirectoryInfo myDirectoryInfo = new DirectoryInfo(yourFolderHere);
   
    // Get a DirectorySecurity object that represents the 
    // current security settings.
    DirectorySecurity myDirectorySecurity = myDirectoryInfo.GetAccessControl();
    // Builds a new user string for who we want to give permissions to
    string User = System.Environment.UserDomainName + "\\" + yourUserName; 
   
    // Creates the permissions to apply 
    myDirectorySecurity.AddAccessRule(new FileSystemAccessRule(User, 
                                      FileSystemRights.FullControl, AccessControlType.Allow));
   
    // Set the new access settings. 
    myDirectoryInfo.SetAccessControl(myDirectorySecurity);
   
    // Showing a Success Message
    MessageBox.Show("Permissions Altered Successfully");
    }
