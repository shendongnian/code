    System.Security.AccessControl.DirectorySecurity dacl = new System.Security.AccessControl.DirectorySecurity();
    dacl.AddAccessRule(new System.Security.AccessControl.FileSystemAccessRule(@"DOMAIN\User1",
        System.Security.AccessControl.FileSystemRights.FullControl,
        System.Security.AccessControl.InheritanceFlags.ContainerInherit |
        System.Security.AccessControl.InheritanceFlags.ObjectInherit,
        System.Security.AccessControl.PropagationFlags.None ,
        System.Security.AccessControl.AccessControlType.Allow));
    System.IO.Directory.CreateDirectory(@"C:\FruitBat", dacl);
