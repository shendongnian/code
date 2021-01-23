    XmlNode result = webService.GetListAndView("My Pictures", string.Empty);
    
    XmlNamespaceManager nsmgr = new XmlNamespaceManager(result.OwnerDocument.NameTable);
    nsmgr.AddNamespace("sp", "http://schemas.microsoft.com/sharepoint/soap/");
    
    string xpathQuery = "sp:View/sp:ViewFields/sp:FieldRef";
    XmlNodeList nodes = result.SelectNodes(xpathQuery, nsmgr);
    
    for (int i = 0; i < nodes.Count; i++)
    {
        Console.WriteLine(nodes[i].Attributes["Name"].Value);
    }
