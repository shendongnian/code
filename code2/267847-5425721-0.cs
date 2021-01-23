    private IEnumerable<string> GetCodes(string name)
    {
        return indexXmlDocument.Descendants("Index")
            .Where(e => e.Attribute("Name").Value == name)
            .Descendants("Code")
            .Select(e => e.Value);
    }
