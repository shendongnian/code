    public static void RemoveAttributes(XNode parent, XName attribute)
    {
        // I'm not sure what would happen if we tried to remove the attribute
        // while querying... seems like a bad idea.
        var list = parent.Descendants()
                         .Attributes(attribute)
                         .ToList();
        foreach (var attribute in list)
        {
            attribute.Remove();
        }
    }
