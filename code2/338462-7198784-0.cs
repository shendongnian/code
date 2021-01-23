    public static class Extensions
    {
       public static string SafeGetAttributeValue(this XElement element, string attribute)
       {
          return (element != null) ? (element.Attribute(attribute) != null)
                                                  ? Attribute(attribute).Value : null
                                               : null
       }
    }
