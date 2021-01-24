    DirectoryInfo directory = new DirectoryInfo("C:\\CreatedFolder");
    DirectorySecurity security = directory.GetAccessControl();
    security.AddAccessRule(new FileSystemAccessRule(@"USERNAME",
                                    FileSystemRights.FullControl,
                                    AccessControlType.Allow));
    directory.SetAccessControl(security);
            
            
        
