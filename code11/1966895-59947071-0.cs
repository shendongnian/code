                      // namespace
                        var nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
                        nsmgr.AddNamespace("a", "http://tempuri.org/XMLSchema.xsd");
                           //get every section in "Thislist" xml file.
                        XmlNodeList sections = xmlDoc.SelectNodes("//a:section", nsmgr);
                        foreach (XmlNode section in sections)
                        {
     				//Get all the explodeddiagrams out for the section
                            XmlNodeList Views = section.SelectNodes("a:views/a:explodeddiagram", nsmgr);
                            
                            
                            foreach (XmlNode ExplodedDiagram in Views)
                            {
                            	//get the mapfile attribute which gives us the explodeddiagram filename
                                string mapfile = ExplodedDiagram.Attributes["mapfile"].Value;
                                //load the mapfile as xmlDocmap
                                XmlDocument xmlDocmap = new XmlDocument();
                                xmlDocmap.Load(mapfile);
                                
                                //go through everymap file in the section and get the key values.
                                XmlNodeList xmlmapkeylist = xmlDocmap.SelectNodes("//*[name()='area'][@key]");
                                foreach (XmlNode areakey in xmlmapkeylist)
                                {
                                    string keyText = areakey.Attributes["key"].Value;
                                    //add the key values from the mapfile into a list
                                    listmapkeys.Add(keyText);
                                }
                            }
                          //get all the key values from the "Thislist" xml file.
                            XmlNodeList keys = section.SelectNodes("a:partslistsectionrows/a:partslistsectionrow/a:key", nsmgr);
                            foreach (XmlNode ListKey in keys)
                            {
                               
                                //add the key values from the each section in "Thislist"xml into a list
                                listsectionkeys.Add(ListKey.InnerText);
                            }
                        }
                        
                        foreach (string mapkey in listmapkeys)
                        {
                        //if the section doesn't contain a key value present in the mapfile. 
                            if(!listsectionkeys.Contains(mapkey))
                            {//output the differences or discrepencies this is going to listBox1 in this case
                                listBox1.Items.Add(hotspot + " not in partslist");
                            }
                          
                        }
                        
                    }
