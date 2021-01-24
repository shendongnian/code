    XDocument ownerDocument = XDocument.Parse("<OwnerDocument></OwnerDocument>");
    XNamespace ssNameSpace = "http://whatever/somenamespace";
    
    // add namespace declaration to the root, set ss as the namespace prefix
    // you only need to do this if the document doesn't already have the namespace declaration
    ownerDocument.Root.Add(new XAttribute(XNamespace.Xmlns + "ss", ssNameSpace.NamespaceName));
    // add our new data element to the root, and add the type attribute prefixed with the ss namespace
    ownerDocument.Root.Add(new XElement("Data", new XAttribute(ssNameSpace + "Type", "String")));
