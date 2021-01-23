    public static XElement Flatten(this XDocument document)
    {
        // used to fix the naming of the namespaces
        var ns = document.Root.Attributes()
                              .Where(aa => aa.IsNamespaceDeclaration
                                        && aa.Name.LocalName != "xmlns")
                              .Select(aa => new { aa.Name.LocalName, aa.Value });
        return new XElement(
            document.Root.Name,
            
            // preserve "specific" xml namespaces
            ns.Select(n => new XAttribute(XNamespace.Xmlns + n.LocalName, n.Value)),
            
            // place root attributes right after the root element
            document.Root.Attributes()
                         .Where(aa => !aa.IsNamespaceDeclaration)
                         .Select(aa => new XAttribute(aa.Name, aa.Value)),
            // then flatten our children
            document.Root.Elements().SelectMany(el => el.Flatten()));
    }
