    private string GetLocalIpAddress()
    {
    	string localIpAddress = string.Empty;
    	NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
    
    	foreach (NetworkInterface nic in nics)
    	{
    		if (nic.OperationalStatus != OperationalStatus.Up)
    		{
    			continue;
    		}
    
    		IPv4InterfaceStatistics adapterStat = (nic).GetIPv4Statistics();
    		UnicastIPAddressInformationCollection uniCast = (nic).GetIPProperties().UnicastAddresses;
    
    		if (uniCast != null)
    		{
    			foreach (UnicastIPAddressInformation uni in uniCast)
    			{
    				if (adapterStat.UnicastPacketsReceived > 0
    					&& adapterStat.UnicastPacketsSent > 0
    					&& nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
    				{
						if (uni.Address.AddressFamily == AddressFamily.InterNetwork)
						{
							localIpAddress = nic.GetIPProperties().UnicastAddresses[0].Address.ToString();
		
							break;
						}
    				}
    			}
    		}
    	}
		return localIpAddress;
    }
