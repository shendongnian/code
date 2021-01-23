    private static void TheAnswer(IXPathNavigable inputElement)
    {
        var schemas = new XmlSchemaSet();
        schemas.Add("http://foo.org/importvalidator.xsd",
                    @"..\..\validator.xsd");
        var settings = new XmlReaderSettings
                           {
                               Schemas = schemas,
                               ValidationFlags =
                                   XmlSchemaValidationFlags.
                                       ProcessIdentityConstraints |
                                   XmlSchemaValidationFlags.
                                       ReportValidationWarnings,
                               ValidationType = ValidationType.Schema
                           };
        settings.ValidationEventHandler +=
            (sender, e) =>
            Console.WriteLine("{0}: {1}", e.Severity, e.Message);
        using (
            XmlReader documentReader =
                inputElement.CreateNavigator().ReadSubtree())
        {
            using (
                XmlReader validatingReader = XmlReader.Create(
                    documentReader, settings))
            {
                while (validatingReader.Read())
                {
                }
            }
        }
    }
