        public static string SerializeObject<T>(T item, string rootName, Encoding encoding)
        {
            XmlWriterSettings writerSettings = new XmlWriterSettings();
            writerSettings.OmitXmlDeclaration = true;
            writerSettings.Indent = true;
            writerSettings.NewLineHandling = NewLineHandling.Entitize;
            writerSettings.IndentChars = "    ";
            writerSettings.Encoding = encoding;
            StringWriter stringWriter = new StringWriter();
            using (XmlWriter xml = XmlWriter.Create(stringWriter, writerSettings))
            {
                XmlAttributeOverrides aor = null;
                if (rootName != null)
                {
                    XmlAttributes att = new XmlAttributes();
                    att.XmlRoot = new XmlRootAttribute(rootName);
                    aor = new XmlAttributeOverrides();
                    aor.Add(typeof(T), att);
                }
                XmlSerializer xs = new XmlSerializer(typeof(T), aor);
                XmlSerializerNamespaces xNs = new XmlSerializerNamespaces();
                xNs.Add("", "");
                xs.Serialize(xml, item, xNs);
            }
            return stringWriter.ToString();
        }
