    Collection<XmlNode> DependentNodes = new Collection<XmlNode>();
            XmlDocument xDoc = new XmlDocument();
           
            xDoc.Load(@"Path_Of_Your_xml");
            foreach (XmlNode node in xDoc.SelectNodes("testfixture"))  // Here I am accessing only root node. Give Xpath if ur requrement is changed
            {
                for (int i = 0; i < node.ChildNodes.Count; i++)
                {
                    DependentNodes.Add(node.ChildNodes[i]);
                }
            }
            string selectedtestcase = "abc_somewords";
            foreach (var s in DependentNodes)
            {
                if (s.InnerText.Contains(selectedtestcase))
                {
                    Console.Write("aaa");
                }
            }
 
