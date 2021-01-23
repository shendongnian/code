    foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
    {
        var addr = ni.GetIPProperties().GatewayAddresses.FirstOrDefault();
        if (addr != null)
        {
            if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
            {
                Console.WriteLine(ni.Name);
                foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                {
                    if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        Console.WriteLine(ip.Address.ToString());
                    }
                }
            }
        }
    }
