    public static void Validate(string xml, string schemaPath)
    {
        //oops: no ValidationFlag property, cant use linq
        //var d = XDocument.Parse(xml);
        //var sc = new XmlSchemaSet();
        //sc.Add(null, schemaPath);
        //sc.CompilationSettings.EnableUpaCheck = false;
        //d.Validate(sc, null);
        XmlReaderSettings Xsettings = new XmlReaderSettings();
        Xsettings.Schemas.Add(null, schemaPath);
        Xsettings.ValidationType = ValidationType.Schema;
        Xsettings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
        Xsettings.Schemas.CompilationSettings.EnableUpaCheck = false;
        Xsettings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
        XmlReader reader = XmlReader.Create(new StringReader(xml), Xsettings);
        while (reader.Read())
        {
        }
    }
    private static void ValidationCallBack(object sender, ValidationEventArgs e)
    {
        if (e.Severity == XmlSeverityType.Warning)
            throw new Exception(string.Format("No validation occurred. {0}", e.Message));
        else
            throw new Exception(string.Format("Validation error: {0}", e.Message));
    }
