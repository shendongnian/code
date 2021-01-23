    public static XElement Flatten(this XDocument document)
    {
        return new XElement(
            document.Root.Name,
            // place root attributes right after the root element
            document.Root.Attributes().Select(aa => new XElement(aa.Name, aa.Value)),
            // then flatten our children
            document.Root.Elements().SelectMany(el => el.Flatten()));
    }
