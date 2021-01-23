    XmlDocument doc = new XmlDocument();
    doc.Load(YourXMLPath);
    XmlNode locationNode = doc["ResourceSets"]["ResourceSet"]["Resources"]["Location"];
    foreach(XmlElement value in locationNode.Children)
    {
        Results _item = new Results();
                        _item.Place = value.Element("Name").Value;
                        _item.Lat = value.Element("Point").Element("Latitude").Value;
                        _item.Long = value.Element("Point").Element("Longitude").Value;
    
                        results.Items.Add(_item);
    
    }
