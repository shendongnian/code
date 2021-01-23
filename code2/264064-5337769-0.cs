    using System.Management;
    using System.Management.Instrumentation;
    using System.Runtime.InteropServices;
    using System.DirectoryServices;
    
    ManagementObjectSearcher Usersearcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem"); 
                ManagementObjectCollection Usercollection = Usersearcher.Get(); 
                string[] sep = { "\\" };
                string[] UserNameDomain = Usercollection.Cast<ManagementBaseObject>().First()["UserName"].ToString().Split(sep, StringSplitOptions.None);
