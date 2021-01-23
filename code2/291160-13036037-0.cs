    public static XDocument ToXDocument( this XmlDocument xmlDocument )
    {
        string outerXml = xmlDocument.OuterXml;
        if(!string.IsNullOrEmpty(outerXml))
        {
            return XDocument.Parse(outerXml, (LoadOptions.PreserveWhitespace |
                 LoadOptions.SetBaseUri |
                 LoadOptions.SetLineInfo));
        }
        else
        {
            return new XDocument();
        }
    }
