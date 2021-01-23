	public void DnsLookup(string hostname)
	{
		var endpoint = new DnsEndPoint(hostname, 0);
		DeviceNetworkInformation.ResolveHostNameAsync(endpoint, OnNameResolved, null);	
	}
	private void OnNameResolved(NameResolutionResult result)
	{
		IPEndPoint[] endpoints = result.IPEndPoints;
		// Do something with your endpoints
	}
