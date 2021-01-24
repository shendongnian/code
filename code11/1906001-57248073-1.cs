            XmlNode secondNode = getSecondNode();// read the second node from the res
            if (secondNode != null)
            {
                XmlNodeList xnList = secondNode.SelectNodes("//NewDataSet//Departments");
                foreach (XmlNode xn in xnList)
                {
                    string code = xn.SelectSingleNode("Code") != null ? xn.SelectSingleNode("Code").Value : "";
                    string Description = xn.SelectSingleNode("Description") != null ? xn.SelectSingleNode("Description").Value : "";
                }
            }
            else
            {
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("bk", "http://www.w3.org/2001/XMLSchema");
                XmlNode firstNode = getFirstNode();// read the first node from the res
                XmlNodeList xnList = firstNode.SelectNodes("//bk:sequence//bk:element", nsmgr);
                foreach (XmlNode xn in xnList)
                {
                    string value = ((System.Xml.XmlElement)xn).Attributes["name"].Value;
                }
            }
  
