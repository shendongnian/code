    public object LoadFromXmlDocument(string xmlDocument, XmlSerializer serializer)
    {
        if (StringUtil.IsEmpty(xmlDocument))
           throw new ArgumentNullException("xmlDocument");
        else if (serializer == null)
           throw new ArgumentNullException("serializer");
    //Initializing instance for textreader
    TextReader reader = new StringReader(xmlDocument);
    //Serializing a textreader content
    object obj = serializer.Deserialize(reader);
    reader.Close();
    reader = null;
    return obj;
    }
