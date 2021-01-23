    using System.Management;
    using System.ComponentModel;
    using System.Configuration.Install;
    
    private void serviceInstaller1_Committed(object sender, InstallEventArgs e)
    {
        ConnectionOptions coOptions = new ConnectionOptions();
        coOptions.Impersonation = ImpersonationLevel.Impersonate;
        ManagementScope mgmtScope = new ManagementScope(@"root\CIMV2", coOptions);
        mgmtScope.Connect();
        ManagementObject wmiService;
        wmiService = new ManagementObject("Win32_Service.Name='" + serviceInstaller1.ServiceName + "'");
        ManagementBaseObject InParam = wmiService.GetMethodParameters("Change");
        InParam["DesktopInteract"] = true;
        ManagementBaseObject OutParam = wmiService.InvokeMethod("Change", InParam, null);
    }
