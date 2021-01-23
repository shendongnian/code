        XDocument doc = new XDocument(
            new XDeclaration("1.0", null, null),
            new XElement("root", "test")
            );
        string xml;
        using (StringWriter msw = new MyStringWriter())
        {
            doc.Save(msw);
            xml = msw.ToString();
        }
        Console.WriteLine(xml);
