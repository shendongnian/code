    using System.Xml; // System.Xml.dll
    
    XmlDocument doc = new XmlDocument();
    doc.LoadXml(xml); // Load(file)
    foreach (XmlNode node in doc.SelectNodes("//Key"))
    {
        keysList.Add(node.InnerText);
    }
    foreach (XmlNode node in doc.SelectNodes("//Value"))
    {
        valuesList.Add(node.InnerText);
    }   
