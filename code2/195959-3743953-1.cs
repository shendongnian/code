    public string LoadFromFile()
    {
        using (System.Xml.XmlReader reader = System.Xml.XmlReader.Create("XMLFile1.xml"))
        {
            reader.MoveToContent();
            reader.ReadToFollowing("credit");
            credits = reader.ReadInnerXml();
        }
        return credits;
    }
