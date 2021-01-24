    var ips = new List<DeviceIPAddress>();
    
    foreach (var ip in result)
    {
    	var info = ip.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    	ips.Add(new DeviceIPAddress { IPv4 = info[0].Trim(), MAC = info[1].Trim(), IPType = info[2].Trim() });
    }
