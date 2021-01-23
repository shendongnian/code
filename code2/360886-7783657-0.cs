    protected string SerializeAnObject(object obj)
    {
        XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
        xmlNamespaces.Add("", "");
        XmlWriterSettings writerSettings = new XmlWriterSettings();
        writerSettings.OmitXmlDeclaration = true;
                        
        XmlSerializer serializer = new XmlSerializer(obj.GetType());
        using (MemoryStream ms = new MemoryStream())
        {
            using (XmlWriter stream = XmlWriter.Create(ms, writerSettings))
            {
                serializer.Serialize(stream, obj, xmlNamespaces);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }
