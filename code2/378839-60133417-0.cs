    public static IDictionary<string, string> GetXmlNamespaces(string sourcePath)
    {
        XDocument y = XDocument.Load(sourcePath);
        XPathNavigator foo = y.CreateNavigator();
        foo.MoveToFollowing(XPathNodeType.Element);
        return foo.GetNamespacesInScope(XmlNamespaceScope.All);
    }
