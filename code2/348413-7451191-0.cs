    XDocument lDoc = XDocument.Load(lXmlDocUri);
    
    foreach (var lElement in lDoc.Element("content").Element(XName.Get("CatalogItems", "sitename.xsd")).Elements(XName.Get("CatalogItem", "sitename.xsd")))
    {
         foreach (var lContentTopic in lElement.Element(XName.Get("ContentItem", "sitename.xsd")).Element(XName.Get("Topics", "sitename.xsd")).Elements(XName.Get("Topic", "sitename.xsd")))
         {
               string lTitle = lContentTopic.Attribute("TopicName").Value;
               Console.WriteLine(lTitle);
         }
    }
