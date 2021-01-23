    public List<string> GetSites(string MachineName)
    {
    
    	List<string> siteList = new List<string>();
    
    	DirectoryEntry iis = new DirectoryEntry(string.Format("IIS://{0}/w3svc/1/root", MachineName));    
    
    	foreach (DirectoryEntry site in iis.Children) {
    
    		if (site.SchemaClassName == "IIsWebServer") {
    			siteList.Add(site.Properties("ServerComment").Value.ToString());
    
    		}
    	}
    
    	return siteList;
    
    }
