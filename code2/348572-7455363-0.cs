    var xmlElementsVehicles  = new XElement("vehicles ", new object[]
                                    {
                                      new XElement("vehicleName", "superVehicles"),
                                      new XElement("vehicleCount", 35),
                                      new XElement("carName", "PORSCHE"),
                                      new XElement("carCount", 2)
                                    });
    var root = new XElement("root", xmlElementsVehicles );
    var myXml = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), root);
    using (var xmlWriter = XmlWriter.Create(stream))
    {
      myXml.Save(xmlWriter);
    }
