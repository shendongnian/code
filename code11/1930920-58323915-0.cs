C-Sharp
        private static void LockFile(string _FullPath)
        {
            File.SetAttributes(_FullPath, File.GetAttributes(_FullPath) | FileAttributes.ReadOnly);
            FileSecurity fSecurity = File.GetAccessControl(_FullPath);
            fSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                FileSystemRights.Delete | FileSystemRights.WriteAttributes, AccessControlType.Deny));
            File.SetAccessControl(_FullPath, fSecurity);
        }
        private static void UnLockFile(string _FullPath)
        {
            FileSecurity fSecurity = File.GetAccessControl(_FullPath);
            
            fSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                FileSystemRights.Delete | FileSystemRights.WriteAttributes, AccessControlType.Allow));
            
            fSecurity.RemoveAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                FileSystemRights.Delete | FileSystemRights.WriteAttributes, AccessControlType.Deny));
                
            File.SetAccessControl(_FullPath, fSecurity);
            File.SetAttributes(_FullPath, FileAttributes.Normal);
        }
