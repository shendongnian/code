    // xmlStream and xsdStream are open streams that 
    // point to the respective xml and xsd files
    public void ReadAndVerify(Stream xmlStream, Stream xsdStream)
    {
        // Read the scheme validation and compile it
        XmlSchemaSet schemaSet = new XmlSchemaSet();
        using (XmlReader r = XmlReader.Create(xsdStream)) 
        {
            schemaSet.Add(XmlSchema.Read(r, null));
        }
        schemaSet.CompilationSettings = new XmlSchemaCompilationSettings();
        schemaSet.Compile();
        // Setup the settings for the reader.
        // This includes the previously compiled schema
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.CloseInput = true;
        // This is the callback method see below
        settings.ValidationEventHandler += ValidationEventHandler;
        settings.ValidationType = ValidationType.Schema;
        settings.Schemas = schemaSet;  // <-- here the schema is set
        // To be honest, this is cut'n'paste. Not sure which flags are really required.
        settings.ValidationFlags =
                XmlSchemaValidationFlags.ReportValidationWarnings |
        XmlSchemaValidationFlags.ProcessIdentityConstraints |
        XmlSchemaValidationFlags.ProcessInlineSchema |
        XmlSchemaValidationFlags.ProcessSchemaLocation;
        // Now the validating reader is created
        using (XmlReader validatingReader = XmlReader.Create(xmlStream, settings)) 
        {
            // This has to be done BEFORE the validating while loop
            XmlDocument x = new XmlDocument();
            x.Load(validatingReader);
            // This is the validation loop
            while (validatingReader.Read()) ;
            // This is the client code that actually uses the XmlDocument nodes.
            XmlNode node = x[RootNode];
            ReadAllParameters(node);
        }
    }
