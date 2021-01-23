    using System.Xml.Linq;
    using System.Linq;
///////////
    XElement root = new XElement("Tests",
      new XElement("Test",
        new XElement("Name", "Test1"),
        new XElement("Type", "A")),
      new XElement("Test",
        new XElement("Name", "Test2"),
        new XElement("Type", "A")),
      new XElement("Test",
        new XElement("Name", "Test3"),
        new XElement("Type", "B")));
    
    string[] result = (from xe in root.Elements()
                       where xe.Element("Type").Value.Equals("A")
                       select xe.Element("Name").Value).ToArray();
