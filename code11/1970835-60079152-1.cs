    using System.Xml.Linq; //namespace
    ...
    string xml = File.ReadAllText(xmlFilePath);
    
    XElement doc = XElement.Parse(xml);
    var result = doc.Elements("recipe")
                    .Where(c => c.Attribute("name").Value == "oven");
                                
    foreach(var element in result.Descendants("ESN"))
    {
        Console.WriteLine(element.Value.ToString());
    }
