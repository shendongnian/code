    public static string GetPhysicalIPAdress()
    {
        foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
        {
            if (ConnectorPresent(ni))
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            return ip.Address.ToString();
                        }
                    }
                }
            }
        }
        return string.Empty;
    }
    private static bool ConnectorPresent(NetworkInterface ni)
    {
        ManagementScope scope = new ManagementScope(@"\\localhost\root\StandardCimv2");
        ObjectQuery query = new ObjectQuery(String.Format(
            @"SELECT * FROM MSFT_NetAdapter WHERE ConnectorPresent = True AND DeviceID = '{0}'", ni.Id));
        ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
        ManagementObjectCollection result = searcher.Get();
        return result.Count > 0;
    }
