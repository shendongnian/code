    /// <summary>Get Network Interface Addresses information of current machine.</summary>
    /// <returns>Returns Array of Tuple of Mac Address, IP Address, and Status.</returns>
    public virtual Tuple<string, IPAddress, OperationalStatus>[] GetNetworkInterfaceAddresses()
    {
        List<Tuple<string, IPAddress, OperationalStatus>> list = new List<Tuple<string, IPAddress, OperationalStatus>>();
        NetworkInterfaceType[] acceptedNetInterfaceTypes = new NetworkInterfaceType[]
                {
                    NetworkInterfaceType.Ethernet,
                    NetworkInterfaceType.Ethernet3Megabit,
                    NetworkInterfaceType.FastEthernetFx,
                    NetworkInterfaceType.FastEthernetT,
                    NetworkInterfaceType.GigabitEthernet,
                    NetworkInterfaceType.Wireless80211
                };
        List<NetworkInterface> adapters = NetworkInterface.GetAllNetworkInterfaces()
            .Where(ni => acceptedNetInterfaceTypes.Contains(ni.NetworkInterfaceType)).ToList();
        #region Get the Mac Address
        Func<NetworkInterface, string> getPhysicalAddress = delegate(NetworkInterface am_adapter)
        {
            PhysicalAddress am_physicalAddress = am_adapter.GetPhysicalAddress();
            return String.Join(":", am_physicalAddress.GetAddressBytes()
                .Select(delegate(byte am_v)
                {
                    string am_return = am_v.ToString("X");
                    if (am_return.Length == 1)
                    {
                        am_return = "0" + am_return;
                    }
                    return am_return;
                }).ToArray());
        };
        #endregion
        #region Get the IP Address
        Func<NetworkInterface, IPAddress> getIPAddress = delegate(NetworkInterface am_adapter)
        {
            IPInterfaceProperties am_ipInterfaceProperties = am_adapter.GetIPProperties();
            UnicastIPAddressInformation am_unicastAddressIP = am_ipInterfaceProperties.UnicastAddresses
                .FirstOrDefault(ua => ua.Address != null && ua.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
            if (am_unicastAddressIP == null)
            {
                return null;
            }
            return am_unicastAddressIP.Address;
        };
        #endregion
        // It's possible to have multiple UP Network Interface adapters. So, take the first order from detected Network Interface adapters.
        NetworkInterface firstOrderActiveAdapter = adapters.FirstOrDefault(ni => ni.OperationalStatus == OperationalStatus.Up);
        string macAddress;
        IPAddress ipAddress;
        if (firstOrderActiveAdapter != null)
        {
            macAddress = getPhysicalAddress(firstOrderActiveAdapter);
            ipAddress = getIPAddress(firstOrderActiveAdapter);
            if (ipAddress == null)
            {
                throw new Exception("Unable to get the IP Address v4 from first order of Network Interface adapter of current machine.");
            }
            list.Add(new Tuple<string, IPAddress, OperationalStatus>(macAddress, ipAddress, firstOrderActiveAdapter.OperationalStatus));
            adapters.Remove(firstOrderActiveAdapter);
        }
        foreach (NetworkInterface adapter in adapters)
        {
            macAddress = getPhysicalAddress(adapter);
            ipAddress = getIPAddress(adapter);
            list.Add(new Tuple<string, IPAddress, OperationalStatus>(macAddress, ipAddress, adapter.OperationalStatus));
        }
        if (firstOrderActiveAdapter == null)
        {
            throw new Exception("Unable to get the Active Network Interface of the current machine.");
        }
        return list.ToArray();
    }
