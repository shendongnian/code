     public static string SerializeObject(object obj)
        {
            XmlSerializerNamespaces XSN = new XmlSerializerNamespaces();
            XSN.Add("bs", "some.domain.api");
            XmlWriterSettings XWS = new XmlWriterSettings();
            XWS.OmitXmlDeclaration = true;
            Stream stream = new MemoryStream();
            XmlTextWriter xtWriter = new XmlTextWriter(stream, new UTF8Encoding(false));
            XmlSerializer ser = new XmlSerializer(obj.GetType());
            ser.Serialize(xtWriter, obj, XSN);
            xtWriter.Flush();
            stream.Seek(0, System.IO.SeekOrigin.Begin);
            string xml = Encoding.UTF8.GetString(((MemoryStream)stream).ToArray());
            return xml;
        }
