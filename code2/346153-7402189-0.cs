    var xmlElementsCustomers = new XElement("Customer", new object[]
                                    {
                                      new XElement("Id", customer.Id),
                                      new XElement("FirstName", customer.FirstName),
                                      new XElement("LastName", customer.LastName),
                                      new XElement("CustomerEmail", customer.CustomerEmail)
                                    });
    var root = new XElement("ArrayOfCustomer", xmlElementsCustomers);
    var myXml = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), root);
    using (var xmlWriter = XmlWriter.Create(stream))
    {
      myXml.Save(xmlWriter);
    }
