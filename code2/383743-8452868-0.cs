    public static void AddAccessEveryone(this FileInfo file, FileSystemRights rights, AccessControlType accessType)
    {
        FileSecurity access = file.GetAccessControl();
        SecurityIdentifier everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
        access.AddAccessRule(new FileSystemAccessRule(everyone, rights, accessType));
        file.SetAccessControl(access);
    }
