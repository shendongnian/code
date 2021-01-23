    var doc = XDocument.Load(@".\MyXml.xml");
    foreach (var test in doc.Descendants("Test"))
    {
        Console.WriteLine("Test #" + test.Attribute("Name").Value);
        foreach (var param in test.Descendants("Param"))
        {
            Console.WriteLine(
                "- {0}: {1}",
                param.Attribute("Name").Value,
                param.Value);
        }
    }
