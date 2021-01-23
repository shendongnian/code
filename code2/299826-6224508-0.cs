     public static T DeserializeObject<T>(string filePath)
       {
           XmlDocument doc = new XmlDocument();
           doc.Load(filePath);
           XmlNodeReader reader = new XmlNodeReader(doc.DocumentElement);
           XmlSerializer ser = new XmlSerializer(typeof(T));
           object obj = ser.Deserialize(reader);
           return (T)obj;
       }
