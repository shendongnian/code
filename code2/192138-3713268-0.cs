    bool modified;
    DirectoryInfo directoryInfo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "MyFolder");
    DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();
    FileSystemAccessRule rule = new FileSystemAccessRule(
        securityIdentifier,
        FileSystemRights.Write |
        FileSystemRights.ReadAndExecute |
        FileSystemRights.Modify,
        InheritanceFlags.ContainerInherit |
        InheritanceFlags.ObjectInherit,
        PropagationFlags.InheritOnly,
        AccessControlType.Allow);
    directorySecurity.ModifyAccessRule(AccessControlModification.Add, rule, out modified);
    directoryInfo.SetAccessControl(directorySecurity);
