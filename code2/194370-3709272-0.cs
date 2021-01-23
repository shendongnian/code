    XElement contacts = XElement.Parse(contactsXml);
    XElement clients = XElement.Parse(clientsXml);
    
    var contactsWithClients =
      from contact in contacts.Elements("Contact")
      join client in clients.Elements("Client")
      on contact.Attribute("ClientId") equals client.Attribute("Id")
      into grp
      select new {
        ContactName = contact.Attribute("Name")
        ClientName = grp.Single().Attribute("Name")
      };
