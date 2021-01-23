     public static void RecycleIis4(string user, string password, string serverName = "LOCALHOST", string appPoolName = "DefaultAppPool")
     {           
           var processToRun = new[] { @"c:\Windows\system32\inetsrv\appcmd recycle APPPOOL " + appPoolName };
           var connection = new ConnectionOptions { Username = user, Password = password };           
           var wmiScope = new ManagementScope(String.Format(@"\\{0}\root\cimv2", serverName), connection);
           var wmiProcess = new ManagementClass(wmiScope, new ManagementPath("Win32_Process"), new ObjectGetOptions());
           wmiProcess.InvokeMethod("Create", processToRun);
     }
Hope this helps.
