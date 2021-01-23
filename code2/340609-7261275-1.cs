    XmlNamespaceManager mgr = new XmlNamespaceManager(xmlresp.NameTable);
    mgr.AddNamespace("ns", "http://integration.fiapi.com");
    for (int i = 0; i < elemList.Count; ++i)
    {
        XmlNode node = elemList[i].SelectSingleNode("ns:Page/ns:Value", mgr);
        // ... convert node.Value as needed
    }
