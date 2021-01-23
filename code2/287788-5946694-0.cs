            // Create a new DirectoryInfo object.
            DirectoryInfo dInfo = new DirectoryInfo(@"\\Server\Test\test1");
            // Get a DirectorySecurity object that represents the 
            // current security settings.
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            // Add the FileSystemAccessRule to the security settings. 
            dSecurity.AddAccessRule(new FileSystemAccessRule(Enviroment.Username,
                                                            FileSystemRights.FullControl, AccessControlType.Allow));
            // Set the new access settings.
            dInfo.SetAccessControl(dSecurity);
