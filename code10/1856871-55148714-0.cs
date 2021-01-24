     NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
     foreach (NetworkInterface adapter in interfaces)
    	{
            //Check if it's connected
    		if (adapter.OperationalStatus == OperationalStatus.Up
                //The network interface uses a mobile broadband interface for WiMax devices.
    			&& (adapter.NetworkInterfaceType == NetworkInterfaceType.Wman
                    //The network interface uses a mobile broadband interface for GSM-based devices.
    				|| adapter.NetworkInterfaceType == NetworkInterfaceType.Wwanpp
                    //The network interface uses a mobile broadband interface for CDMA-based devices.
    				|| adapter.NetworkInterfaceType == NetworkInterfaceType.Wwanpp2))
    		{
    			//adapter probably is cellular
    		}                
    	}
