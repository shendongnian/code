    private static bool IsLanIP(IPAddress address)
    {
        var interfaces = NetworkInterface.GetAllNetworkInterfaces();
        foreach (var iface in interfaces)
        {
            var properties = iface.GetIPProperties();
            foreach (var ifAddr in properties.UnicastAddresses)
            {
                if (ifAddr.IPv4Mask != null && 
                    ifAddr.Address.AddressFamily == AddressFamily.InterNetwork &&
                    CheckMask(ifAddr.Address, ifAddr.IPv4Mask, address))
                    return true;
            }
        }
        return false;
    }
    private static bool CheckMask(IPAddress address, IPAddress mask, IPAddress target)
    {
        if (mask == null)
            return false;
        var ba = address.GetAddressBytes();
        var bm = mask.GetAddressBytes();
        var bb = target.GetAddressBytes();
        if (ba.Length != bm.Length || bm.Length != bb.Length)
            return false;
        for (var i = 0; i < ba.Length; i++)
        {
            int m = bm[i];
            int a = ba[i] & m;
            int b = bb[i] & m;
            if (a != b)
                return false;
        }
        return true;
    }
