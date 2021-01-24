    // Add reference to System.Management
    // using System.Management;
    string sLinkPath = "C:\\Users\\Christian\\Desktop";
    string sLinkName = "MpCmdRun.lnk";
    string sRequest = "SELECT * FROM Win32_ShortcutFile where Name=\"" + sLinkPath + "\\" + sLinkName + "\"";
    sRequest = sRequest.Replace("\\", "\\\\");
    try
    {
        ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", sRequest);
    
        foreach (ManagementObject queryObj in searcher.Get())
        {
            Console.WriteLine("Target: {0}", queryObj["Target"]);
            // Target: C:\Program Files\Windows Defender\MpCmdRun.exe
        }
    }
    catch (ManagementException me)
    {
        System.Windows.Forms.MessageBox.Show("An error occurred while querying for WMI data: " + me.Message);
    }
