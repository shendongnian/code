                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("XMLFile1.xml");
                //xDoc.Load(response);
    
                // cycle through each child node 
                foreach (XmlNode node in xDoc.DocumentElement.ChildNodes)
                {
                    // first node is the url ... have to go to nexted loc node 
                    foreach (XmlNode locNode in node)
                    {
                        // thereare a couple child nodes here so only take data from node named loc 
                        var nodeList = locNode.ChildNodes;
                        for (int i = 0; i < nodeList.Count; i++)
                        {
                            var childNodes = nodeList[i].ChildNodes;
                            for (int j = 0; j < childNodes.Count; j++)
                            {
                                Console.WriteLine($"DocId: "+childNodes[j].ChildNodes[1].InnerText + Environment.NewLine);
                                //childNodes[j].ChildNodes.AsQueryable()
                                //childNodes[i]
                            }
                        }
                       
                    }
                }
    
                Console.ReadKey();
