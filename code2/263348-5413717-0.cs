    System.Management.ConnectionOptions oConnectionOptions = new System.Management.ConnectionOptions();
    {
        oConnectionOptions.Username = ServerManagement.GetServerUser();
        oConnectionOptions.Password = ServerManagement.GetServerPassword();
    }
    ManagementPath oPath = new ManagementPath("\\\\" + ServerManagement.GetServerAddress() + "\\root\\cimv2");
    ManagementScope oScope = new ManagementScope(oPath, oConnectionOptions);
    try
    {
        oScope.Connect();
        ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DesktopMonitor");
        ManagementObjectCollection obj = searcher.Get();
        foreach (ManagementObject service in obj)
        {
            this.DisplayHeight = Convert.ToInt16(service["ScreenHeight"]);
            this.DisplayWidth = Convert.ToInt16(service["ScreenWidth"]);
        }
    }
    catch (Exception)
    {
        MessageBox.Show("Cannot connect to server, please try again later.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
