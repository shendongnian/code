    XmlSerializer serializer = new XmlSerializer(typeof(MyClass));
    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
    ns.Add("example", "http://www.w3.org");
        using (var ms = new MemoryStream())
        {
            using (TextWriter writer = new StreamWriter(ms))
            {
                var xmlSerializer = new XmlSerializer(typeof(MyClass));
                xmlSerializer.Serialize(writer, myClassInstance, ns);
                XNode node = XElement.Parse(Encoding.ASCII.GetString(ms.ToArray()));
            }
        }
