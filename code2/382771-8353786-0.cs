            string dir = Path.GetDirectoryName(tbFileLocation.Text);
            
            DirectoryInfo di = new DirectoryInfo(dir);
            DirectorySecurity ds = di.GetAccessControl();
            FileSystemRights fsRights = FileSystemRights.FullControl;
            FileSystemAccessRule accessRule = new FileSystemAccessRule("Dummy", fsRights, AccessControlType.Allow);
            ds.AddAccessRule(accessRule);
            
            di.SetAccessControl(ds);
