    var pathToXmlFile = @"c:\folder\file.xml";
    using (XmlReader reader = XmlReader.Create(  
        pathToXmlFile, 
        new XmlReaderSettings { DtdProcessing = DtdProcessing.Parse }
        ))
    {
        while (reader.Read())
        {
            if (reader.NodeType == XmlNodeType.DocumentType)
            {
                var dtd = reader.GetAttribute("SYSTEM"); // sample.dtd
            }
         }
     }
