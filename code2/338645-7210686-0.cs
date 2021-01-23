    public class _Default : Page
    {
      [DllImport("advapi32.dll", SetLastError = true)]
      static extern bool LogonUser(string principal, string authority,string password, uint logonType, uint logonProvider, out IntPtr token);
      [DllImport("kernel32.dll", SetLastError = true)]
      static extern bool CloseHandle(IntPtr handle); 
      protected void OnClick(object sender, EventArgs e)
      {
        IntPtr token = IntPtr.Zero;
        WindowsImpersonationContext impUser = null;
        try
        {        
          bool result = LogonUser("administrator", "contoso",
                                "P@$$W0rd", 3, 0, out token);
          if (result)
          {
            WindowsIdentity wid = new WindowsIdentity(token);
            impUser = wid.Impersonate();
            try
            {
              ManagementScope scope = new ManagementScope("root\\MicrosoftIISv2");
              scope.Path.Server = "srvcontoso";
              scope.Path.Path = "\\\\srvcontoso\\root\\MicrosoftIISv2";
              scope.Path.NamespacePath = "root\\MicrosoftIISv2";
              scope.Connect();
              ManagementObject appPool = new ManagementObject(scope, new ManagementPath("IIsApplicationPool.Name='W3SVC/AppPools/DefaultAppPool'"), null);
              appPool.InvokeMethod("Recycle", null, null);
             }
             catch (System.Exception ex)
             {
             } 
           }
        }
        catch
        {        
        }
        finally
        {         
          if (impUser  != null)
            impUser .Undo();
        
          if (token != IntPtr.Zero)
            CloseHandle(token);
        }                 
      }
    }    
