    XmlDocument d = new XmlDocument();
    d.Load("XmlFile1.xml");
    
    XmlElement items = d.DocumentElement;//(XmlElement)d.GetElementById("items");
    XmlElement item = (XmlElement)items.ChildNodes[0];
    XmlElement itemProperty1 = item["itemProperty1"]; 
    XmlElement itemProperty2 = item["itemProperty2"];
    XmlElement propertyWithSubProperties1 = item["propertyWithSubProperties1"];
    XmlElement subProp1 = propertyWithSubProperties1["subprop1"];
    XmlElement subProp2 = propertyWithSubProperties1["subprop2"];
    XmlElement deeperPropertyWithSubProperties1 = propertyWithSubProperties1["deeperPropertyWithSubProperties1"];
    XmlElement deeperSubProperty1 = deeperPropertyWithSubProperties1["deeperSubProperty1"];
    XmlElement deeperSubProperty2 = deeperPropertyWithSubProperties1["deeperSubProperty2"];
    
    Console.WriteLine(itemProperty1.InnerText);
    Console.WriteLine(itemProperty2.InnerText);
    Console.WriteLine(subProp1.InnerText);
    Console.WriteLine(subProp2.InnerText);
    Console.WriteLine(deeperSubProperty1.InnerText);
    Console.WriteLine(deeperSubProperty2.InnerText);
    Console.ReadKey();
