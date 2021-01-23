    XDocument result = XDocument.Parse(e.Result.ToString());
    XmlNamespaceManager nsManager = new XmlNamespaceManager(new NameTable());
    XNamespace namespace = result.Root.GetDefaultNamespace();
    nsManager.AddNamespace("def", namespace.NamespaceName);
    IEnumerable<XElement> ele = result.XPathSelectElements("/def:GetAllUserCollectionFromWeb/def:Users/def:User", nsManager);
