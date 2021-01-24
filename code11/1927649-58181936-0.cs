    public void LoadXsd()
    {
        string resourceName = "DefaultNamespace.specs.info.IErrorInfo.xsd";
        Assembly assembly = Assembly.GetExecutingAssembly();
        XmlSchema xsd = XmlSchema.Read(assembly.GetManifestResourceStream(resourceName), _XsdSchema_ValidationEventHandler);
        XmlSchemaSet schemaSet = new XmlSchemaSet();
        schemaSet.Add(xsd);
    }
    private void _XsdSchema_ValidationEventHandler(object sender, ValidationEventArgs e)
    {
        _Logger.Error($"XSD validation error: {e.Message}");
    }
