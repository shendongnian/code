    public static string GetXml<T>(this T obj, XmlSerializer serializer = null, bool omitStandardNamespaces = false)
    {
        XmlSerializerNamespaces ns = null;
        if (omitStandardNamespaces)
        {
            ns = new XmlSerializerNamespaces();
            ns.Add("", ""); // Disable the xmlns:xsi and xmlns:xsd lines.
        }			
        using (var textWriter = new StringWriter())
        {
            var settings = new XmlWriterSettings() { Indent = true }; // For cosmetic purposes.
            using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                (serializer ?? new XmlSerializer(obj.GetType())).Serialize(xmlWriter, obj, ns);
            return textWriter.ToString();
        }
    }
