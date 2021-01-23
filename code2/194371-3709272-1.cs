    XElement contacts = XElement.Parse(contactsXml);
    XElement clients = XElement.Parse(clientsXml);
    
    var contactsWithClients =
      from contact in contacts.Elements("Contact")
      join client in clients.Elements("Client")
      on contact.Attribute("ClientId").Value equals client.Attribute("Id").Value
      into grp
      select new {
        ContactName = contact.Attribute("Name").Value,
        ClientName = grp.Single().Attribute("Name").Value
      };
