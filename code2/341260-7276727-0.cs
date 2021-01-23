    foreach (XmlNode xmlIter in doc.SelectNodes
             ("/refentry/refsect1[@id='parameters']/variablelist/varlistentry"))
    {
        XmlNode xmlNode = xmlIter.SelectSingleNode("term/parameter");
        Console.WriteLine("Identifier = {0}", xmlNode.InnerText);
        
        xmlNode = xmlIter.SelectSingleNode("listitem");
        Console.WriteLine("Documentation = {0}", xmlNode.InnerText);
    }
