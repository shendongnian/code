    var xns = new XmlSerializerNamespaces();
    var serializer = new XmlSerializer(users.GetType());
    xns.Add(string.Empty, string.Empty);
    //...
    serializer.Serialize(stream, users, xns);
