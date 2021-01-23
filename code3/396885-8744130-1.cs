    public static XElement parseWithNamespaces(String xml, String[] namespaces) {
        XmlNamespaceManager nameSpaceManager = new XmlNamespaceManager(new NameTable());
        foreach (String ns in namespaces) { nameSpaceManager.AddNamespace(ns, ns); }
        return XElement.Load(new XmlTextReader(xml, XmlNodeType.Element, 
            new XmlParserContext(null, nameSpaceManager, null, XmlSpace.None)));
    }
