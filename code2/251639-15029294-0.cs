            foreach (NetworkInterface ni in niList)
            {
                switch (ni.NetworkInterfaceType)
                {
                    case NetworkInterfaceType.Ethernet: // 10baseT
                    case NetworkInterfaceType.FastEthernetT: // 100baseT
                    case NetworkInterfaceType.GigabitEthernet:
                        GatewayIPAddressInformationCollection gwIPColl = ni.GetIPProperties().GatewayAddresses;
                        UnicastIPAddressInformation uniIPInfo = null;
                        UnicastIPAddressInformationCollection IPcoll = ni.GetIPProperties().UnicastAddresses;
                        if (IPcoll.Count <= 0)
                        {
                            LogFile.LogMe("No valid unicast IP address");
                            broken = true;
                            break; // Cannot continue if we don't have an IP in the colletion
                        }
