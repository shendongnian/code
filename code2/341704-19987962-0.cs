    DirectoryInfo info = new DirectoryInfo(path[x]);
    DirectorySecurity security = info.GetAccessControl();
    security.AddAccessRule(new FileSystemAccessRule(logonName, FileSystemRights.Modify, InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Allow));
    security.AddAccessRule(new FileSystemAccessRule(logonName, FileSystemRights.Modify, InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
    info.SetAccessControl(security); 
