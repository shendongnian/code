    public string GetLocalIpAddress()
    {
        UnicastIPAddressInformation mostSuitableIp = null;
        var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
        foreach (var network in networkInterfaces)
        {
            if (network.OperationalStatus != OperationalStatus.Up)
                continue;
            var properties = network.GetIPProperties();
            if (properties.GatewayAddresses.Count == 0)
                continue;
                
            foreach (var address in properties.UnicastAddresses)
            {
                if (address.Address.AddressFamily != AddressFamily.InterNetwork)
                    continue;
                if (IPAddress.IsLoopback(address.Address))
                    continue;
                if (!address.IsDnsEligible)
                {
                    if (mostSuitableIp == null)
                        mostSuitableIp = address;
                    continue;
                }
                // The best IP is the IP got from DHCP server
                if (address.PrefixOrigin != PrefixOrigin.Dhcp)
                {
                    if (mostSuitableIp == null || !mostSuitableIp.IsDnsEligible)
                        mostSuitableIp = address;
                    continue;
                }
                return address.Address.ToString();
            }
        }
        return mostSuitableIp != null 
            ? mostSuitableIp.Address.ToString()
            : "";
    }
