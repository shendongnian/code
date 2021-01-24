    using (StringReader stream = new StringReader("<dictionary> <string key=\"Test\"> <value><![CDATA[<b>Test Data</b>]]></value> </string> </dictionary>"))
    {
        XDocument doc = XDocument.Load(stream);
        XElement element = doc.Descendants("value").First();
        string value = element.LastNode.ToString();
        Console.WriteLine(value);
    }
