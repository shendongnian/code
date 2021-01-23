    XmlDocument doc = new XmlDocument();
    doc.Load(@"C:\temp\X.loadtest.xml");
    
    Dictionary<string, string> namespaces = new Dictionary<string, string>();
    XmlNodeList nlAllNodes = doc.SelectNodes("//*");
    foreach (XmlNode n in nlAllNodes)
    {
        if (n.NodeType != XmlNodeType.Element) continue;
    
        if (!String.IsNullOrEmpty(n.NamespaceURI) && !namespaces.ContainsKey(n.Name))
        {
            namespaces.Add(n.Name, n.NamespaceURI);
        }
    }
    // Inspect the namespaces dictionary to write the code below
    
    XmlNamespaceManager nMgr = new XmlNamespaceManager(doc.NameTable);
    // Sometimes this works
    nMgr.AddNamespace("ns1", doc.DocumentElement.NamespaceURI); 
    // You can make the first param whatever you want, it just must match in XPath queries
    nMgr.AddNamespace("javaurlencoder", "java.net.URLEncoder"); 
    
    XmlNodeList iter = doc.SelectNodes("//ns1:TestProfile", nMgr);
    foreach (XmlNode n in iter)
    {
        // Do stuff
    }
