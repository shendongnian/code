    XmlDocument xml = new XmlDocument();
    // xmlContent contains your XML file
    xml.LoadXml(xmlContent);
    // get collections of nodes representing translations in particular languages
    var enNodes = xml.GetElementsByTagName("en");
    var deNodes = xml.GetElementsByTagName("de");
    string[] lines = new string[enNodes.Count];
    for (int i = 0; i < enNodes.Count; i++)
        lines[i] = $"{enNodes[i].InnerText},{deNodes[i].InnerText}";
    File.WriteAllLines(@"path to text file", lines);
