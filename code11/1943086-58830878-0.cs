                XmlDocument responseDoc = new XmlDocument();
                responseDoc.LoadXml(str);
                XmlNodeList nodes = responseDoc.SelectNodes("Transitions/Transition");
                foreach (XmlNode node in nodes)
                {
                    if (node.Attributes.Count > 0 && node.Attributes["From"] != null)
                    {
                        string temp = string.Empty;
                        if (node.Attributes["To"] != null)
                            temp = node.Attributes["To"].Value;
                        if (string.Compare(node.Attributes["From"].Value, "A", true) == 0)
                        {
                            XmlNode nodeset = node.SelectSingleNode("Triggers/Trigger");
                            if (nodeset != null && nodeset.Attributes.Count > 0 &&
                                nodeset.Attributes["NameRef"] != null)
                            {
                                if (string.Compare(nodeset.Attributes["NameRef"].Value, "2", true) == 0)
                                    Console.WriteLine(temp);
                            }
                        }
                    }
                }
