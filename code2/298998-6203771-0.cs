    const string xmlString =
    @"<Items>
        <Item>
            <Code>Test</Code>
            <Value>Test</Value>
        </Item>
        <Item>
            <Code>MyCode</Code>
            <Value>MyValue</Value>
        </Item>
        <Item>
            <Code>AnotherItem</Code>
            <Value>Another value</Value>
        </Item>
    </Items>";
    var doc = new XmlDocument();
    doc.LoadXml(xmlString);
    XmlElement element = (XmlElement)doc.SelectSingleNode("Items/Item[Code='MyCode']/Value");
    Console.WriteLine(element.InnerText);
