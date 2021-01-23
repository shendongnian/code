    var nics = NetworkInterface.GetAllNetworkInterfaces();
    foreach (var nic in nics)
    {
    	if (nic.OperationalStatus == OperationalStatus.Up)
    	{
    		var mac = nic.GetPhysicalAddress().ToString();
    		if (mac == "your:connections:mac:address")
    		{
    			/* ... */
    		}
    	}
    }
