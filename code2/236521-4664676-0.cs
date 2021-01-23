    var xml = XElement.Parse(@"<root>
        <pair>foo</pair>
        <pair></pair>
        <single id=""42"" />
        <single />
    </root>");
    
    foreach (var element in xml.Elements())
    {
        Console.WriteLine("{0}: {1}", element.IsEmpty, element);
    }
    // False: <pair>foo</pair>
    // False: <pair></pair>
    // True: <single id="42" />
    // True: <single />
