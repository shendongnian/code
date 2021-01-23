    private static Dictionary<IPAddress, UseIP> _eachNIC = new Dictionary<IPAddress, UseIP>();
    public static UseIP ForNIC(IPAddress nic)
    {
        lock (_eachNIC)
        {
            UseIP useIP = null;
            if (!_eachNIC.TryGetValue(nic, out useIP))
            {
                useIP = new UseIP(nic);
                _eachNIC.Add(nic, useIP);
            }
            return useIP;
        }
    }
