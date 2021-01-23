    void RemoveNamespace(XDocument xdoc)
    {
        foreach (XElement e in xdoc.Root.DescendantsAndSelf())
        {
            if (e.Name.Namespace != XNamespace.None)
            {
                e.Name = XNamespace.None.GetName(e.Name.LocalName);
            }
            if (e.Attributes().Any(a => a.IsNamespaceDeclaration || a.Name.Namespace != XNamespace.None))
            {
                e.ReplaceAttributes(e.Attributes().Select(a => a.IsNamespaceDeclaration ? null : a.Name.Namespace != XNamespace.None ? new XAttribute(XNamespace.None.GetName(a.Name.LocalName), a.Value) : a));
            }
        }
    }
