        public static string ObjectToXmlString(object _object)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = false;
            settings.OmitXmlDeclaration = true;
            settings.NewLineChars = "";
            settings.NewLineHandling = NewLineHandling.None;
            StringWriter stringWriter = new StringWriter();
            XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            XmlSerializer serializer = new XmlSerializer(_object.GetType());
            serializer.Serialize(xmlWriter, _object, namespaces);
            string xmlStr = stringWriter.ToString();
            return xmlStr;
        }
