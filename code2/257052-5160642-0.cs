    // Code answer by Jon Skeet.
    var qClients = xdoc.Root
           .Element(XKey.clients)
           .Elements(XKey.client)
           .Select(client => {
               dynamic o = new ExpandoObject();
               o.OnlineDetails = new ExpandoObject();
               o.OnlineDetails.Password = client.Element(XKey.onlineDetails)
                                                .Element(XKey.password).Value;
               o.OnlineDetails.Roles = client.Element(XKey.onlineDetails)
                                             .Element(XKey.roles)
                                             .Elements(XKey.roleId)
                                             .Select(xroleid => xroleid.Value);
               return o; 
           });
