        string orderCode = "FOO";
        string paramCode = "BAR";
        XDocument doc = XDocument.Load("file.xml");
        XNamespace abc = "http://www.mycompany.com/xyz/abc";
        XElement value = 
            doc
            .Descendants(abc + "order")
            .First(o => o.Element(abc + "orderCode").Value == orderCode)
            .Descendants(abc + "orderParameter")
            .First(p => p.Element(abc + "parameterCode").Value == paramCode)
            .Element(abc + "billedValue")
            .Element(abc + "value");
        value.SetElementValue(abc + "numericalValue", 20);
        value.SetElementValue(abc + "stringValue", "twenty");
        doc.Save(Console.Out); // do doc.Save("file.xml") to overwrite
