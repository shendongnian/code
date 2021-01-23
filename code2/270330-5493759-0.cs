    using System.Linq;
    using System.Xml.Linq;
    ...
    XDocument doc = new XDocument(
        new XElement("as",
            a.Select(item => new XElement("a",
               new XAttribute("value", item)
            )
        ),
        new XElement("bs",
            b.Select(item => new XElement("b",
               new XAttribute("value", item)
            )
        ),
        new XElement ("cs",
            c.Select(item => new XElement("c",
               new XAttribute("key", item.Key),
               new XAttribute("value", item.Value)
            )
        )
    );
