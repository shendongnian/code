    public static string Serialize(object input)
    {
        if (input == null)
            return null;
        System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(input.GetType());
        using (MemoryStream ms = new MemoryStream())
        using (StreamReader sr = new StreamReader(ms))
        {
            ser.Serialize(ms, input);
            ms.Seek(0, 0);
            return sr.ReadToEnd();
        }
    }
