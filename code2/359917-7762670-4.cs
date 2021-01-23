    public static string Serialize<t>(t obj)
    {
        using (StringWriter writer = new StringWriter())
        {
            XmlSerializer formatter = new XmlSerializer(typeof(t));
            formatter.Serialize(writer, obj);
    
            return writer.ToString();
        }
    }
    
    public static t Deserialize<t>(string xml)
    {
        using (StringReader reader = new StringReader(xml))
        {
            XmlSerializer formatter = new XmlSerializer(typeof(t));
            return (t)formatter.Deserialize(reader);
        }
    }
