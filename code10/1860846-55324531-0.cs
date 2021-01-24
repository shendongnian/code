    using System.IO;
    using System.Security.AccessControl;
    private void SetFileAccess(string path)
        {
            var fileSecurity = new FileSecurity();
            var readRule = new FileSystemAccessRule("identityOfUser", FileSystemRights.ReadData, AccessControlType.Allow);
            var writeRule = new FileSystemAccessRule("identityOfUser", FileSystemRights.WriteData, AccessControlType.Allow);
            var noExecRule = new FileSystemAccessRule("identityOfUser", FileSystemRights.ExecuteFile, AccessControlType.Deny);
            fileSecurity.AddAccessRule(readRule);
            fileSecurity.AddAccessRule(writeRule);
            fileSecurity.AddAccessRule(noExecRule);
            File.SetAccessControl(path, fileSecurity);
        }
