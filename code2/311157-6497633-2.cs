    private void ProcessAndDumpXml()
    {
        StreamReader xmlStream = new StreamReader("example1.xml");
        XmlNode root = GetRootNode(xmlStream);
    
        // process nodes
        // ...
    }
    
    private XmlNode GetRootNode(StreamReader streamReader)
    {            
        XmlDocument xmlDocument = new XmlDocument();            
        XmlNamespaceManager nsmgr = new XmlNamespaceManager(new NameTable());
        nsmgr.AddNamespace("dfs", "schema1");
        nsmgr.AddNamespace("d", "schema1");
        nsmgr.AddNamespace("xdado", "schema1");
        XmlParserContext context = new XmlParserContext(null, nsmgr, null, XmlSpace.None);
        XmlReaderSettings xset = new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment };
        XmlReader rd = XmlReader.Create(streamReader, xset, context);
        xmlDocument.Load(rd);
    
        return xmlDocument.DocumentElement.FirstChild;
    }
