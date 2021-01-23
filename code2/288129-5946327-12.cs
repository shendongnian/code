    using System.Xml; // System.Xml.dll
    
    XmlDocument doc = new XmlDocument();
    doc.LoadXml(xml); // Load(file)
    var ns = new XmlNamespaceManager(doc.NameTable);
    ns.AddNamespace("tcm", "http://www.tridion.com/ContentManager/5.0");
    ns.AddNamespace("xlink", "http://www.w3.org/1999/xlink");
    foreach (XmlNode node in doc.SelectNodes("//*[local-name()=\"Key\"]))
    {
        keysList.Add(node.InnerText);
    }
    foreach (XmlNode node in doc.SelectNodes("//*[local-name()=\"Value\"]))
    {
        valuesList.Add(node.InnerText);
    }   
