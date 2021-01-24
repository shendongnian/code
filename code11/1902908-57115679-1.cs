    XmlDocument ownerDocument = new XmlDocument();
    ownerDocument.LoadXml("<OwnerDocument></OwnerDocument>");
    // add namespace declaration to the root, set ss as the namespace prefix
    var nsDeclarationAttribute = ownerDocument.CreateAttribute("xmlns:ss");
    nsDeclarationAttribute.Value = "http://whatever/somenamespace";
    ownerDocument.DocumentElement.Attributes.Append(nsDeclarationAttribute);
    // add data element, and add a type attribute to that
    var dataElement = ownerDocument.CreateElement("Data");
    var typeAttribute = ownerDocument.CreateAttribute("Type", "http://whatever/somenamespace");
    typeAttribute.Value = "String";            
    dataElement.Attributes.Append(typeAttribute);
    // append to main document
    ownerDocument.DocumentElement.AppendChild(dataElement);
