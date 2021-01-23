    using System.Security;
    using System.Security.AccessControl;
    using Microsoft.Win32;
    string user = Environment.UserDomainName + "\\" + Environment.UserName;
    RegistryKey rk = 
    RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).
    OpenSubKey("SOFTWARE",true);    
    
    RegistrySecurity rs = new RegistrySecurity();
    rs.AddAccessRule(new RegistryAccessRule(user,
                RegistryRights.WriteKey | RegistryRights.ReadKey | RegistryRights.Delete,
                InheritanceFlags.None,
                PropagationFlags.None,
                AccessControlType.Allow));
    rk = Registry.CurrentUser.CreateSubKey("RegistryRightsExample", 
                RegistryKeyPermissionCheck.Default, rs);
