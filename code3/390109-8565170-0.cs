    var doc = XDocument.Parse(@"<?xml version=""1.0"" encoding=""utf-8""?>
    <xml>
    <root>
    <Item>
    <taxids>
    <string>330</string>
    <string>374</string>
    <string>723</string>
    <string>1087</string>
    <string>1118</string>
    <string>1121</string>
    </taxids>
    </Item>
    </root>
    </xml>");
    
    var query = doc.XPathSelectElement("xml/root/Item/taxids");
    
    Console.WriteLine(query);
