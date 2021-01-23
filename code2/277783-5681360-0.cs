    System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
    doc.LoadXml(xmlfilename);
    
    XmlElement elem = doc.GetElementByName("keyname");
    var allDescendants = myElement.DescendantsAndSelf();
    var allDescendantsWithAttributes = allDescendants.SelectMany(elem =>
        new[] { elem }.Concat(elem.Attributes().Cast<XContainer>()));
    
    foreach (XContainer elementOrAttribute in allDescendantsWithAttributes)
    {
        // ...
    }
