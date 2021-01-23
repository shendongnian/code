    public static IEnumerable<XElement> Flatten(this XElement element)
    {
        // first return ourselves
        yield return new XElement(
            element.Name,
            // And the flattened sequence of our children
            element.Elements().SelectMany(el => el.Flatten()));
        // Then return our own attributes
        foreach (var attribute in element.Attributes())
        {
            yield return new XElement(attribute.Name, attribute.Value);
        }
    }
