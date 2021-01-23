    TestWrapper doc;
    using(var reader = XmlReader.Create(source))
    {
        var serializer = new XmlSerializer(typeof (TestWrapper));
        doc = (TestWrapper) serializer.Deserialize(reader);
    }
    // et voila; loaded! prove it:
    foreach(var item in doc.Tests)
    {
        Console.WriteLine("{0}: {1}, {2}",
            item.TestName, item.TestType, item.TestResult);
    }
