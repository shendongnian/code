    public static IEnumerable<XElement> Flatten(this XElement element)
    {
        // first return ourselves
        yield return new XElement(
            element.Name,
            
            // Output our text if we have no elements
            !element.HasElements ? element.Value : null,
            
            // Or the flattened sequence of our children if they exist
            element.Elements().SelectMany(el => el.Flatten()));
        // Then return our own attributes (that aren't xmlns related)
        foreach (var attribute in element.Attributes()
                                         .Where(aa => !aa.IsNamespaceDeclaration))
        {
            // check if the attribute has a namespace,
            // if not we "borrow" our element's
            var isNone = attribute.Name.Namespace == XNamespace.None;
            yield return new XElement(
                !isNone ? attribute.Name
                        : element.Name.Namespace + attribute.Name.LocalName,
                attribute.Value);
        }
    }
