    using System.Xml; // System.Xml.dll
    
    XmlDocument doc = new XmlDocument();
    doc.LoadXml(xml); // Load(file)
    foreach (XmlNode node on doc.SelectNodes("//Key"))
    {
        keysList.Add(node.InnerText);
    }
    foreach (XmlNode node on doc.SelectNodes("//Value");
    {
        valuesList.Add(node.InnerText);
    }   
