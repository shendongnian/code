    public static string Serialize<T>(T data)
        {
           XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
           StringWriter sw = new StringWriter();
           xmlSerializer.Serialize(sw, data);
           return sw.ToString();
        }
