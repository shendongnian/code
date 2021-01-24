    public static void SetAccessRule(string directory)
    {
        var dInfo = new DirectoryInfo(directory);
        System.Security.AccessControl.DirectorySecurity sec = dInfo.GetAccessControl();
        FileSystemAccessRule accRule = new FileSystemAccessRule(Environment.UserDomainName + "\\" + Environment.UserName, FileSystemRights.FullControl, AccessControlType.Allow);
        sec.AddAccessRule(accRule);
        
        dInfo.SetAccessControl(sec);
    }
