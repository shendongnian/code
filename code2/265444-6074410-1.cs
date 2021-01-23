    using System;
    using System.Diagnostics;
    // ...
    using (new ProcessPrivileges.PrivilegeEnabler(Process.GetCurrentProcess(), Privilege.TakeOwnership))
    {
        directoryInfo = new DirectoryInfo(path);
        directorySecurity = directoryInfo.GetAccessControl();
    
        directorySecurity.SetOwner(WindowsIdentity.GetCurrent().User);
        Directory.SetAccessControl(path, directorySecurity);    
    }
