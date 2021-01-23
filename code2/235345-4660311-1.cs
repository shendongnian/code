    foreach(XmlAttribute attribute in doc.DocumentElement.Attributes)
    {
        var url = namespaceManager.LookupNamespace(attribute.LocalName);
        if(url != null && url != attribute.Value)
        {
            namespaceManager.RemoveNamespace(attribute.LocalName, url);
            namespaceManager.AddNamespace(attribute.LocalName, attribute.Value);
        }
    }
