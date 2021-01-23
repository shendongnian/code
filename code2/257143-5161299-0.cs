    Func<XElement, ExpandoObject> convert = client => {
        dynamic o = new ExpandoObject();
        o.OnlineDetails = new ExpandoObject();
        o.OnlineDetails.Password = 
           client.Element(XKey.onlineDetails).Element(XKey.password).Value;
        o.OnlineDetails.Roles = client.Element(XKey.onlineDetails).
           Element(XKey.roles).Elements(XKey.roleId).
           Select(xroleid => xroleid.Value);
        // More fields TBD.
        return o;
    }
    var qClients =
        from client in xdoc.Root.Element(XKey.clients).Elements(XKey.client)
        select convert(client);
