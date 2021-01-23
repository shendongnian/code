    /// <summary> 
    /// This utility function displays all the IP addresses that likely route to the Internet. 
    /// </summary> 
    public static void DisplayInternetIPAddresses()
    {
        var sb = new StringBuilder();
        // Get a list of all network interfaces (usually one per network card, dialup, and VPN connection) 
        var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
        foreach (var network in networkInterfaces)
        {
            // Read the IP configuration for each network 
            var properties = network.GetIPProperties();
            // Only consider those with valid gateways
            var gateways = properties.GatewayAddresses.Select(x => x.Address).Where(
                x => !x.Equals(IPAddress.Any) && !x.Equals(IPAddress.None) && !x.Equals(IPAddress.Loopback) &&
                !x.Equals(IPAddress.IPv6Any) && !x.Equals(IPAddress.IPv6None) && !x.Equals(IPAddress.IPv6Loopback));
            if (gateways.Count() < 1)
                continue;
            // Each network interface may have multiple IP addresses 
            foreach (var address in properties.UnicastAddresses)
            {
                // Comment these next two lines to show IPv6 addresses too
                if (address.Address.AddressFamily != AddressFamily.InterNetwork)
                    continue;
                sb.AppendLine(address.Address + " (" + network.Name + ")");
            }
        }
        MessageBox.Show(sb.ToString());
    }
