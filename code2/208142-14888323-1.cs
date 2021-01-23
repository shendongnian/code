    public static string ObjectToXmlString(object _object)
    {
        string xmlStr = string.Empty;
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = false;
        settings.OmitXmlDeclaration = true;
        settings.NewLineChars = string.Empty;
        settings.NewLineHandling = NewLineHandling.None;
        using (StringWriter stringWriter = new StringWriter())
        {
            using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings))
            {
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);
                XmlSerializer serializer = new XmlSerializer(_object.GetType());
                serializer.Serialize(xmlWriter, _object, namespaces);
                xmlStr = stringWriter.ToString();
                xmlWriter.Close();
            }
            stringWriter.Close();
        }
        return xmlStr;
    }
