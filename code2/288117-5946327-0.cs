    using System.Xml; // System.Xml.dll
    
    var doc = new XmlDocument();
    doc.LoadXml(xml); // Load(file)
    var keys = doc.SelectNodes("//Key");
    var values = doc.SelectNodes("//Value");
