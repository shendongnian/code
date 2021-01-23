    new XmlWriterSettings { 
        OmitXmlDeclaration = true, 
        ConformanceLevel = ConformanceLevel.Fragment 
    }
    
        public static string FormatXml(string xml)
        {
            if (string.IsNullOrEmpty(xml))
                return string.Empty;
    
            try
            {
                XmlDocument document = new XmlDocument();
                document.LoadXml(xml);
                using (MemoryStream memoryStream = new MemoryStream())
                using (XmlWriter writer = XmlWriter.Create(
                    memoryStream, 
                    new XmlWriterSettings { 
                        Encoding = Encoding.Unicode, 
                        OmitXmlDeclaration = true, 
                        ConformanceLevel = ConformanceLevel.Fragment, 
                        Indent = true, 
                        NewLineOnAttributes = false }))
                {
                    document.WriteContentTo(writer);
                    writer.Flush();
                    memoryStream.Flush();
                    memoryStream.Position = 0;
                    using (StreamReader streamReader = new StreamReader(memoryStream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
            catch (XmlException ex)
            {
                return "Unformatted Xml version." + Environment.NewLine + ex.Message;
            }
            catch (Exception ex)
            {
                return "Unformatted Xml version." + Environment.NewLine + ex.Message;
            }
        }
