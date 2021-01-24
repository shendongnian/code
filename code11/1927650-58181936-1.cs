    public void LoadAllXsdFiles()
    {
        XmlSchemaSet schemaSet = new XmlSchemaSet();
        var assembly = Assembly.GetExecutingAssembly();
        var allXsdFiles = assembly.GetManifestResourceNames().Where(r => r.EndsWith(".xsd"));
        foreach (string xsdFile in allXsdFiles)
        {
            XmlSchema xsd = XmlSchema.Read(assembly.GetManifestResourceStream(xsdFile), _XsdSchema_ValidationEventHandler);
            schemaSet.Add(xsd);
        }
    }
