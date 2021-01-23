    foreach (FileSystemRights permission in Enum.GetValues(typeof(FileSystemRights)))
    {
        myDirectorySecurity.AddAccessRule(
            new FileSystemAccessRule(user,
                                     permission,
                                     InheritanceFlags.ContainerInherit |
                                         InheritanceFlags.ObjectInherit |
                                         InheritanceFlags.None,
                                     PropagationFlags.None,
                                     AccessControlType.Allow));
    }
