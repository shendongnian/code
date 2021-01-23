    public static TestClass FromXElement(XElement element)
    {
        string name = (string) element.Element("Name");
        string type  = (string) element.Element("Type");
        List<string> members = element.Descendants("Member")
                                      .Select(x => x.Value)
                                      .ToList();
        return new TestClass(name, type, members);
    }
