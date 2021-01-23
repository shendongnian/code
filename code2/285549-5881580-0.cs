    var doc = XDocument.Parse(xml);
    var element = doc.Root.Elements().
                      Where(x => x.Name.LocalName == "XProperty" && 
                                 x.Attributes().Any(
                                     y => y.Name == "Name" &&
                                     y.Value == "DeviceInfo")
                           ).SingleOrDefault();
    if(element != null)
    {    
        // change it
    }
    else
    {
        // add a new one
        doc.Root.Add(new XElement(doc.Root.Name.Namespace+ "XProperty", 
                                  new XAttribute("Name", "DeviceInfo2")));
    }
