    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace MyProj.Extensions
    {
        public static class XmlExtension
        {
            public static string Serialize<T>(this T value)
            {
                if (value == null) return string.Empty;
                var xmlSerializer = new XmlSerializer(typeof(T));
                using (var stringWriter = new StringWriter())
                {
                    using (var xmlWriter = XmlWriter.Create(stringWriter,new XmlWriterSettings{Indent = true}))
                    {
                        xmlSerializer.Serialize(xmlWriter, value);
                        return stringWriter.ToString();
                    }    
                }
            }
        }
    }
