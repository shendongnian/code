    using (var sw = new StringWriter())
    {
        using (var xw = XmlWriter.Create(sw, new XmlWriterSettings {
            OmitXmlDeclaration = true }))
        {
            var obj = new PersonRowSet
            {
                Item = new Person
                {
                    first_name = "John",
                    last_name = "Smith",
                    middle_name = "James"
                }
            };
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            var ser = new XmlSerializer(typeof(PersonRowSet));
            ser.Serialize(xw, obj, ns);
        
        }
        string xml = sw.ToString();
    }
