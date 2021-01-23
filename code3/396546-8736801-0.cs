    ManagementPath path = new ManagementPath(@"\\" + txtRemoteComputer.Text + @"\root\cimv2");
    System.Management.ManagementScope oMs = new System.Management.ManagementScope(path, conO);
    oMs.Connect();
    ObjectQuery query = new ObjectQuery(
                    "SELECT * FROM Win32_Process");
    ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher(oMs, query);
    foreach (ManagementObject queryObj in searcher.Get())
    {
