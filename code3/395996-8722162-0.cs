    public static string Serialize<T>(T item, bool includeHeader = false)
    {
        MemoryStream memStream = new MemoryStream();
        using (XmlTextWriter textWriter = new XmlTextWriter(memStream, Encoding.Unicode))
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            serializer.Serialize(textWriter, item);
            memStream = textWriter.BaseStream as MemoryStream;
        }
        if (memStream != null)
            if (includeHeader)
            {
                return @"<?xml version=""1.0"" encoding=""utf-8"" ?>" + Environment.NewLine + Encoding.Unicode.GetString(memStream.ToArray());
            }
            else
            {
                return Encoding.Unicode.GetString(memStream.ToArray());
            }
        else
            return null;
    }
