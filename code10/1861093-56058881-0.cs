    const string path = @"C:\temp\incoming";
    var fileSystem = new MockFileSystem();
    fileSystem.AddDirectory(path);
    var diFactory = fileSystem.DirectoryInfo;
    var directoryInfo = diFactory.FromDirectoryName(path);
    var directorySecurity = directoryInfo.GetAccessControl();
    var currentUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
    directorySecurity.AddAccessRule(new FileSystemAccessRule(currentUser , FileSystemRights.Read, AccessControlType.Allow));
