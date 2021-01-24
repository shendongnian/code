    private static void GrantFullControl(string directoryPath, string username)
    {
        if (!Directory.Exists(directoryPath))
            return;
        var directorySecurity = Directory.GetAccessControl(directoryPath);
        directorySecurity.AddAccessRule(new FileSystemAccessRule(username, FileSystemRights.FullControl,
            InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None,
            AccessControlType.Allow));
        Directory.SetAccessControl(directoryPath, directorySecurity);
    }
