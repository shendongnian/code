    private static string GetData(string jobResultXml, string pipeName)
    {
        StringBuilder result = new StringBuilder();
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.ConformanceLevel = ConformanceLevel.Fragment;
    
        using (StringReader stringReader = new StringReader(jobResultXml))
        using (XmlReader xmlReader = XmlReader.Create(stringReader, settings))
        {
        }
