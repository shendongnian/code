                String xmlWithoutNamespace =
                    @"<Folio><Node1>Value1</Node1><Node2>Value2</Node2><Node3>Value3</Node3></Folio>";
                String prefix ="vs";
                String testNamespace = "http://www.testnamespace/vs/";
                XmlDocument xmlDocument = new XmlDocument();
    
                XElement folio = XElement.Parse(xmlWithoutNamespace);
                XmlElement folioNode = xmlDocument.CreateElement(prefix, folio.Name.LocalName, testNamespace);
    
                var nodes = from node in folio.Elements()
                            select node;
               
                foreach (XElement item in nodes)
                {
                    var node = xmlDocument.CreateElement(prefix, item.Name.ToString(), testNamespace);
                    node.InnerText = item.Value;
                    folioNode.AppendChild(node);
                }
    
                xmlDocument.AppendChild(folioNode);
