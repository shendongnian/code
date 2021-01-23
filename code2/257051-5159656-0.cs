    public dynamic ClientXmlToExpandoObject(System.Xml.Linq.XElement client)
    {
        dynamic result = new ExpandoObject();
        result.OnlineDetails = new
            {
                Password = client.Element(XKey.onlineDetails).
                    Element(XKey.password).Value,
                Roles = client.Element(XKey.onlineDetails).
                    Element(XKey.roles).Elements(XKey.roleId).
                    Select(xroleid => xroleid.Value)
                // More online detail fields TBD
            };
        return result;
    }
