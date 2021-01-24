    static void Main(string[] args)
    {
        var path = Directory.EnumerateFiles(@"C:\Program Files (x86)\Stuff\Noodles", "*.config", SearchOption.AllDirectories);
        foreach (var xmlfile in path)
        {
    	    var doc = XDocument.Load(xmlfile );
    	    var endpointsToUpdate = doc
    			.Descendants("endpoint")
    			.Where(x => new Uri((string)x.Attribute("address")).Host != "localhost")
    			.ToArray();
    		
    		// skip if there is nothing to update
    		if (!endpointsToUpdate.Any()) return;
    	
    	    foreach (var endpoint in endpointsToUpdate)
    	    {
    	        string address = (string)endpoint.Attribute("address");
    	        string pattern = "//[^:]+";
    	        address = Regex.Replace(address, pattern, "//" + GetIPAddress(Dns.GetHostName()));
    	
    	        endpoint.Attribute("address").SetValue(address);
    	    }
    		
    	    doc.Save(xmlfile );
        }
    }
