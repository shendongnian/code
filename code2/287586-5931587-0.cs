    static ArrayList DeserializeArray()
    {
        if(!File.Exists("SiteList.xml")
            return new ArrayList();
        XmlSerializer deserializer = new XmlSerializer(typeof(ArrayList));
        TextReader textReader = new StreamReader("SiteList.xml");
        ArrayList siteList;
        siteList = (ArrayList)deserializer.Deserialize(textReader);
        textReader.Close();
        return siteList;
    }
