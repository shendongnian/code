    public static IEnumerable<XmlElement> FindMatchingElements(XmlElement match,
        IEnumerable<XmlElement> elements, params string[] attributeNames)
    {
        return elements.Where(
            element => attributeNames.All(
                name => element.GetAttribute(name) == match.GetAttribute(name)));
    }
