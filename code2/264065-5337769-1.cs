    using System.Management;
    using System.Management.Instrumentation;
    using System.Runtime.InteropServices;
    using System.DirectoryServices;
    
    ManagementObjectSearcher Usersearcher = new ManagementObjectSearcher("Select * From Win32_ComputerSystem Where (Name LIKE 'ws%' or Name LIKE 'it%')"); 
                ManagementObjectCollection Usercollection = Usersearcher.Get(); 
                string[] sep = { "\\" };
                string[] UserNameDomain = Usercollection.Cast<ManagementBaseObject>().First()["UserName"].ToString().Split(sep, StringSplitOptions.None);
