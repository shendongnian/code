        public static string ToXmlString(this XmlSchema xsd)
        {
            var xmlWriterSettings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = false,
                Encoding = Encoding.UTF8
            };
            using (var memoryStream = new MemoryStream())
            {
                using (var xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings))
                {
                    xsd.Write(xmlWriter);
                }
                memoryStream.Position = 0; 
                using (var sr = new StreamReader(memoryStream))
                {
                    return sr.ReadToEnd();
                }
            }
        }
