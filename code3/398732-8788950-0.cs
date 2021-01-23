    NetworkInterface networkInterface = NetworkInterface.GetAllNetworkInterfaces().Where(ipProp => ipProp.GetIPProperties().UnicastAddresses.FirstOrDefault(ip => ip.Address.ToString().Equals("YOUR_IP")) != null).FirstOrDefault();
    if (networkInterface != null)
    {
    	Console.WriteLine(networkInterface.GetPhysicalAddress());
    }
