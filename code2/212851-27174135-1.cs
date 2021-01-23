    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace MyProj.Extensions
    {
        public abstract class XmlExtension
        {
            public static string Serialize(object obj)
            {
                if (obj == null) return string.Empty;
    
                var xmlserializer = new XmlSerializer(obj.GetType());
    
                using (StringWriter stringWriter = new StringWriter())
                {
                    using (XmlWriter writer = XmlWriter.Create(stringWriter))
                    {
                        xmlserializer.Serialize(writer, obj);
                        return stringWriter.ToString();
                    }
                }
            }
        }
    }
