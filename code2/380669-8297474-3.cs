    private static string SerializeXml<T>(T item)
    {
        DataContractSerializer ser = new DataContractSerializer(item.GetType());
        StringBuilder sb = new StringBuilder();
        XmlWriterSettings settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };
        using (XmlWriter writer = new XmlWriter(sb, settings))
        {
            ser.WriteObject(writer, item);
        }
        return sb.ToString();
    }
