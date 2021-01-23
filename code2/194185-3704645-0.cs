    public static void CreateWithEveryoneFullControlIfAdmin(this DirectoryInfo source)
    {
        if (IsAdmin())
        {
            DirectorySecurity directorySecurity = Directory.GetAccessControl(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
            FileSystemAccessRule accessRule
                = new FileSystemAccessRule(@"BUILTIN\Users", FileSystemRights.FullControl,
                    InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit,
                    PropagationFlags.None,
                    AccessControlType.Allow);
            bool modified = false;
            directorySecurity.ModifyAccessRule(AccessControlModification.Add,
                accessRule,
                out modified);
            if (modified)
            {
                source.Create(directorySecurity);
            }
            else
            {
                source.Create();
            }
        }
        else
        {
            source.Create();
        }
    }
    public static bool IsAdmin()
    {
        WindowsIdentity identity = WindowsIdentity.GetCurrent();
        WindowsPrincipal principal = new WindowsPrincipal(identity);
        return principal.IsInRole(WindowsBuiltInRole.Administrator);
    }
