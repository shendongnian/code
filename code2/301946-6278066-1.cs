    XmlReader xmlRdr = XmlReader.Create("Test.XML");
    // Parse the file
    while (xmlRdr.Read())
    {
        switch (xmlRdr.NodeType)
        {
            case XmlNodeType.Element:
                // You may need to capture the last element to provide a context
                // for any comments you come across... so copy xmlRdr.Name, etc.
                break;
            case XmlNodeType.Comment:
                // Do something with xmlRdr.value
