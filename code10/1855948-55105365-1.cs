    public static object LoadXaml(TextReader textReader)
    {
        var settings = new XamlObjectWriterSettings
        {
            AfterBeginInitHandler = (s, e) => Debug.Print($"Before deserializing {e.Instance}"),
            AfterEndInitHandler = (s, e) => Debug.Print($"After deserializing {e.Instance}")
        };
        using (var xmlReader = XmlReader.Create(textReader))
        using (var xamlReader = new XamlXmlReader(xmlReader))
        using (var xamlWriter = new XamlObjectWriter(xamlReader.SchemaContext, settings))
        {
            XamlServices.Transform(xamlReader, xamlWriter);
            return xamlWriter.Result;
        }
    }
