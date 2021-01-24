    public static string RegxFind(string XmlPath)
    {
        var xml = XDocument.Load(XmlPath);
        return xml.Root.Descendants("reg1").FirstOrDefault()?.Value;
    }
