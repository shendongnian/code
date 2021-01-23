    // Load the Schema Into Memory. The Error handler is also presented here.
    StringReader sr = new StringReader(File.ReadAllText("schemafile.xsd"));
    XmlSchema sch = XmlSchema.Read(sr,SchemaErrorsHandler);
    // Create the Reader settings.
    XmlReaderSettings settings = new XmlReaderSettings();
    settings.Schemas.Add(sch);
    // Create an XmlReader specifying the settings.
    StringReader xmlData = new StringReader(File.ReadAllText("xmlfile.xml"));
    XmlReader xr = XmlReader.Create(xmlData,settings);
    // Use the Native .NET Serializer (probably u cud substitute the Xsd2Code serializer here.
    XmlSerializer xs = new XmlSerializer(typeof(SerializableClass));
    var data = xs.Deserialize(xr);
