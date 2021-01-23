    using System.Xml.Linq;
    ...
    public void Foo()
    {
        var doc = new XDocument(
            new XDeclaration("1.0", "Windows-1252", "yes"),
            new XElement("settings",
                new XElement("typeofsetting",
                    new XElement("word", new XAttribute("name", "add")))));
        doc.Save("SomeFile.xml");
    }
