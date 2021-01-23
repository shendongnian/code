    public static (List<IPAddress> V4, List<IPAddress> V6) GetLocal()
    {
        List<IPAddress> foundV4 = new List<IPAddress>();
        List<IPAddress> foundV6 = new List<IPAddress>();
        NetworkInterface.GetAllNetworkInterfaces().ToList().ForEach(ni =>
        {
            if (ni.GetIPProperties().GatewayAddresses.FirstOrDefault() != null)
            {
                ni.GetIPProperties().UnicastAddresses.ToList().ForEach(ua =>
                {
                    if (ua.Address.AddressFamily == AddressFamily.InterNetwork) foundV4.Add(ua.Address);
                    if (ua.Address.AddressFamily == AddressFamily.InterNetworkV6) foundV6.Add(ua.Address);
                });
            }
        });
        return (foundV4.Distinct().ToList(), foundV6.Distinct().ToList());
    }
