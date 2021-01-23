    ConnectionOptions wmiConnOpts = new ConnectionOptions();
    wmiConnOpts.Impersonation = ImpersonationLevel.Impersonate;
    wmiConnOpts.Authentication = System.Management.AuthenticationLevel.Default;
    wmiConnOpts.EnablePrivileges = true;
    ManagementScope wmiLoc = 
       new ManagementScope(String.Format(@"\\{0}\root\cimv2", remoteMachine ),
          wmiConnOpts);
    ManagementPath wmiProcPath = new ManagementPath("Win32_Process");
    ManagementClass wmiProc = new ManagementClass(wmiLoc, wmiProcPath, null);
    wmiProc.InvokeMethod("Create", new Object[] { runFile });
