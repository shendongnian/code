    public sealed class TestXmlNodeRemoval
    {
        public static void RemoveNode()
        {
            var xmlDocument = new XmlDocument();
            var xmlTrafficPattern = xmlDocument.CreateElement("TrafficPattern");
            xmlDocument.AppendChild(xmlTrafficPattern);
            xmlTrafficPattern.AppendChild(CreateWayPoint(xmlDocument, 
                               "001", "0.36", "48", "31.7363644", "11", "57.53425"));
            xmlTrafficPattern.AppendChild(CreateWayPoint(xmlDocument, 
                               "090", "0.56", "48", "31.7363644", "11", "57.53425"));
            xmlTrafficPattern.AppendChild(CreateWayPoint(xmlDocument, 
                               "240", "0.56", "48", "31.7363644", "11", "57.53425"));
            xmlTrafficPattern.AppendChild(CreateWayPoint(xmlDocument, 
                               "346", "0.56", "48", "31.7363644", "11", "57.53425"));
            Console.WriteLine(@"Original traffic pattern:");
            DisplayXmlDocument(xmlDocument);
            // create an arbitrary criterion to remove an element
            const string radialToRemove = @"090";
            Console.WriteLine(@"Remove node with radial=" + radialToRemove);
            if (xmlDocument.DocumentElement != null)
            {
                for (var i = 0; i < xmlDocument.DocumentElement.ChildNodes.Count; ++i)
                {
                    var radial = 
                    xmlDocument.DocumentElement.ChildNodes[i].SelectSingleNode("Radial");
                    if (radial == null || (radial.InnerText != radialToRemove))
                    {
                        continue;
                    }
                    var nodeToRemove = xmlDocument.DocumentElement.ChildNodes[i];
                    // note that you need to remove node from the Parent
                    if (nodeToRemove.ParentNode != null)
                    {
                        nodeToRemove.ParentNode.RemoveChild(nodeToRemove);
                    }
                    break;
                }
            }
            Console.WriteLine(@"New traffic pattern:");
            DisplayXmlDocument(xmlDocument);
        }
    }
