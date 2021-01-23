    public static string EncodeGuidListToXml(IList<Guid> guids)
    {
        if (elementsToEncode == null || elementsToEncode.Count == 0)
        {
            return "";
        }
        return new XDocument(
            new XElement("Root",
                guids.Select(guid => new XElement("Item", guid.ToString().ToUpper()))
            )).ToString();
            
    }
