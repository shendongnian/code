    // Key is {Subnet, Subnet Mask}.
    // Value is list of IPs in that range.
    public static IDictionary<Tuple<IPAddress, IPAddress>, ISet<IPAddress>> AllocateToSubnets(IEnumerable<Tuple<IPAddress, IPAddress>> ips)
    {
        var dic = new Dictionary<Tuple<IPAddress, IPAddress>, ISet<IPAddress>>();
        foreach (var item in ips)
        {
            var subnet = Tuple.Create(GetSubnetAddress(item.Item1, item.Item2), item.Item2);
            ISet<IPAddress> set;
            if (!dic.TryGetValue(subnet, out set))
                dic.Add(subnet, set = new HashSet<IPAddress>());
            if (!set.Add(item.Item1))
            {
                // Throw an error if you are looking for duplicates.
            }
        }
        return dic;
    }
    private static IPAddress GetSubnetAddress(IPAddress address, IPAddress mask)
    {
        var b1 = address.GetAddressBytes();
        var b2 = mask.GetAddressBytes();
        if (b1.Length != b2.Length)
            throw new InvalidOperationException("IPAddress and its mask do not share the same family.");
        for (var i = 0; i < b1.Length; i++)
            b1[i] &= b2[i];
        return new IPAddress(b1);
    }
