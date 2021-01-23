    public static void RemoveAttributes(XNode parent, XName attribute)
    {
        parent.Descendants()
              .Attributes(attribute)
              .Remove();
    }
