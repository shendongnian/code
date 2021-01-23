    public static class XmlExtender
    {
       public static XAttribute AttributeOrDefault(this XElement el, XName name, string defValue)
       {
          var v = el.Attribute(name);
          return v == null ? new XAttribute(name, defValue) : v;
       }
       public static string AttributeValue(this XElement el, XName name, string defValue)
       {
          var v = el.Attribute(name);
          return v == null ? defValue : v.Value;
       }
    }
