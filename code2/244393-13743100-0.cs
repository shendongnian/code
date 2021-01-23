    public static SqlXml ConvertString2SqlXml(string xmlData)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        MemoryStream m = new MemoryStream(encoding.GetBytes(xmlData));
        return new SqlXml(m);
    }
