    private static ToExpando(XElement client)
    {
        // Possibly use an object initializer instead?
        dynamic o = new ExpandoObject();    
        o.OnlineDetails = new ExpandoObject();
        o.OnlineDetails.Password = client.Element(XKey.onlineDetails)
                                         .Element(XKey.password).Value;
        o.OnlineDetails.Roles = client.Element(XKey.onlineDetails)
                                      .Element(XKey.roles)
                                      .Elements(XKey.roleId)
                                      .Select(xroleid => xroleid.Value);
        return o;
    }
