    public static void GrantWideOpenFilePermissions(string fullPath) {
       DirectoryInfo dInfo = new DirectoryInfo(fullPath);
       DirectorySecurity dSecurity = dInfo.GetAccessControl();
       dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
       dInfo.SetAccessControl(dSecurity);
    }
