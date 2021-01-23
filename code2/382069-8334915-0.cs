     public static T FromXML<T>(string xml)
     {
         using (StringReader stringReader = new StringReader(xml))
         {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(stringReader);
         }
     }
     public string ToXML<T>(T obj)
     {
        using (StringWriter stringWriter = new StringWriter(new StringBuilder()))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            xmlSerializer.Serialize(stringWriter, obj);
            return stringWriter.ToString();
        }
     }
