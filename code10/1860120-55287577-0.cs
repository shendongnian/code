    private string GenerateSsml(string locale, string gender, string name, IEnumerable<XNode> nodes)
    {
        var ssmlDoc = new XDocument(
                          new XElement("speak",
                              new XAttribute("version", "1.0"),
                              new XAttribute(XNamespace.Xml + "lang", "en-US"),
                              new XElement("voice",
                                  new XAttribute(XNamespace.Xml + "lang", locale),
                                  new XAttribute(XNamespace.Xml + "gender", gender),
                                  new XAttribute("name", name),
                                  nodes)));
        return ssmlDoc.ToString();
    }
