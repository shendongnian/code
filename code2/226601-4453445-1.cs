    Dim customers = (From c In xDoc.Descendants("customer")Order By c.Attribute("CustomerID").Value
     Select New Customer() With { _
      .ID = c.Attribute("CustomerID").Value, _
      .CompanyName = c.Attribute("CompanyName").Value, _
      .ContactName = c.Attribute("ContactName").Value, _
      .ContactTitle = c.Attribute("ContactTitle").Value, _
      .Address = c.Attribute("Address").Value, _
      .City = c.Attribute("City").Value, _
      .State = c.Attribute("State").Value, _
      .ZIPCode = c.Attribute("ZIPCode").Value, _
      .Phone = c.Attribute("Phone").Value _
    }).ToList()
