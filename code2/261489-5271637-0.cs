    public static List<string> getTwitterHandles(String ocXml)
        var xml = XDocument.Parse(ocXml);
        var list = xml.Descendants("Company")
                .Concat(xml.Descendants("Organization"))
                .Select(element => element.Value)
                .ToList();
        return list;
    }
