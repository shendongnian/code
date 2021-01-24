string sharedFolder = Path.Combine(Application.CommonAppDataPath, "InfoConfig");
 if (!Directory.Exists(sharedFolder))
 {
    DirectoryInfo directoryInfo = Directory.CreateDirectory(sharedFolder);
    DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();
    directorySecurity.SetAccessRuleProtection(true, false);
    FileSystemRights fileSystemRights = 
            FileSystemRights.FullControl | 
            FileSystemRights.Modify | 
            FileSystemRights.Read | 
            FileSystemRights.Delete;
    SecurityIdentifier usersSid = 
            new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null);
    FileSystemAccessRule rule =  new FileSystemAccessRule(usersSid, fileSystemRights,InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Allow);
    directorySecurity.AddAccessRule(rule);
    bool result;
    directorySecurity.ModifyAccessRule(AccessControlModification.Set, rule, out result);
    if (!result)
        {
            throw new InvalidOperationException("Failed to give full-control permission to all users for path " + path);
        }
    FileSystemAccessRule inheritedRule = new FileSystemAccessRule(
    usersSid,
    fileSystemRights,
    InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
    PropagationFlags.InheritOnly,
    AccessControlType.Allow);
    bool inheritedResult;
    directorySecurity.ModifyAccessRule(AccessControlModification.Add, inheritedRule, out inheritedResult);
    if (!inheritedResult)
    {
        throw new InvalidOperationException("Failed to give full-control permission inheritance to all users for " + path);
    }
    directoryInfo.SetAccessControl(directorySecurity);
}
