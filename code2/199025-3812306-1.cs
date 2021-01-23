    using System;
    using System.Linq;
    using System.Xml;
    var doc = new XmlDocument();
    doc.LoadXml(xml);
    var nodes = doc.SelectNodes("Root/Child");
    var result = nodes 
        .OfType<XmlNode>()
        .Select(n =>
            new
            {
                Column1 = n.Attributes["val1"].Value,
                Column2 = n.Attributes["val1"].Value
            });
