    System.DirectoryServices.DirectorySearcher mySearcher = new DirectorySearcher(mySearchRoot, myFilter, myPropertiesList);
    System.DirectoryServices.SearchResultCollection myResults = mySearcher.FindAll();
    foreach (System.DirectoryServices.SearchResult result in myResults)
    {
       var propertyNames = result.Properties.PropertyNames.Cast<String>().ToList<String>();
       if (!propertyNames.Contains("proxyaddresses")) 
       {
          // This property does not exist. Abort.
          continue;
       }
       List<string> proxyAddresses = result.Properties["proxyaddresses"].Cast<String>().ToList();
	   // Do something with proxyAddresses
    }
