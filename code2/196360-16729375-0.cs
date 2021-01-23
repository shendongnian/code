    string adminUserName = Environment.UserName;
                DirectorySecurity dirService = Directory.GetAccessControl(directory + hexID);
                FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName,FileSystemRights.FullControl, AccessControlType.Deny);
                dirService.AddAccessRule(fsa);//add
                Directory.SetAccessControl(directory + hexID, dirService);
