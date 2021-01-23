    public IEnumerable<XElement> PathDescendants(
        this XElement element,
        params XName[] names)
    {
        return new[] { element }.PathDescendants(names);
    }
    public IEnumerable<XElement> PathDescendants(
        this IEnumerable<XElement> elements,
        params XName[] names)
    {
        return names.Aggregate(elements,
                               (current, name) => current.Descendants(name));
    }
