    Dim customers = (From c In xDoc.Descendants("customer")Order By c.Attribute("CustomerID").Value
     Select New Customer() With { _
     Key .ID = c.Attribute("CustomerID").Value, _
     Key .CompanyName = c.Attribute("CompanyName").Value, _
     Key .ContactName = c.Attribute("ContactName").Value, _
     Key .ContactTitle = c.Attribute("ContactTitle").Value, _
     Key .Address = c.Attribute("Address").Value, _
     Key .City = c.Attribute("City").Value, _
     Key .State = c.Attribute("State").Value, _
     Key .ZIPCode = c.Attribute("ZIPCode").Value, _
     Key .Phone = c.Attribute("Phone").Value _
    }).ToList()
