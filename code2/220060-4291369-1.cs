    // This section not shown in the blog
    var xDoc = XDocument.Load(xmlDocNm); //This is your xml path value 
    // Changes to XML Document here
       
    // .Net writes the XML declaration using lower case utf-8.
    //  <?xml version="1.0" encoding="utf-8"?>
    // It is not suppesed to matter but NiceForm expects the delcaration to be uppercase.
    //  <?xml version="1.0" encoding="UTF-8"?>
    // We are using a XMLWriter with a custom Encoding to captialize the UTF
    // Set various options to retrive the desired output
    var settings = new XmlWriterSettings {
      Encoding = new UpperCaseUTF8Encoding(), // Key setting option for this example
      NewLineHandling = System.Xml.NewLineHandling.Replace,
      NewLineOnAttributes = true,
      Indent = true                           // Generate new lines for each element
    };
    using (var xmlWriter =XmlTextWriter.Create(xmlDocNm, settings)) {
      xDoc.Save(xmlWriter);
    }
