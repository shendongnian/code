    XElement root = XElement.Load("TestConfig.xml");
    IEnumerable<XElement> tests =
        from el in root.Elements("Test")
        where (string)el.Element("CommandLine") == "Examp2.EXE"
        select el;
    foreach (XElement el in tests)
        Console.WriteLine((string)el.Attribute("TestId"));
