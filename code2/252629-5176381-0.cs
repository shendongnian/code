    public void WriteXml(List<string> filePaths, List<string> fileName)
            {
                //creating xml file
                XmlElement mainNode, descNode;
                XmlText pathText, nameText;
    
                XmlDocument xmlDoc = new XmlDocument();
    
                // Write down the XML declaration
                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
    
                // Create the root element
                XmlElement rootNode = xmlDoc.CreateElement("ImageStore");
                xmlDoc.InsertBefore(xmlDeclaration, xmlDoc.DocumentElement);
                xmlDoc.AppendChild(rootNode);
    
                for (int i = 0; i < filePaths.Count; i++)
                {
                    //Console.WriteLine("first xml image "+i);
                    // Create a new <Category> element and add it to the root node
                    XmlElement parentNode = xmlDoc.CreateElement("Image");
    
                    // Set attribute name and value!
                    parentNode.SetAttribute("ID", "01");
    
                    xmlDoc.DocumentElement.PrependChild(parentNode);
    
                    // Create the required nodes
                    mainNode = xmlDoc.CreateElement("URL");
                    descNode = xmlDoc.CreateElement("Name");
                    //XmlElement activeNode = xmlDoc.CreateElement("Active");
    
                    // retrieve the text
                    pathText = xmlDoc.CreateTextNode(filePaths[i]);
                    nameText = xmlDoc.CreateTextNode(fileName[i]);
                    XmlText activeText = xmlDoc.CreateTextNode("true");
    
                    // append the nodes to the parentNode without the value
                    parentNode.AppendChild(mainNode);
                    parentNode.AppendChild(descNode);
                    parentNode.AppendChild(activeNode);
    
                    // save the value of the fields into the nodes
                    mainNode.AppendChild(pathText);
                    descNode.AppendChild(nameText);
                    activeNode.AppendChild(activeText);
    
    
    
                }//end of for loop
    
                // Save to the XML file. Checks if previous file exist
                if (File.Exists(Application.StartupPath + "/imageStore.xml"))
                {
                    File.Delete(Application.StartupPath + "/imageStore.xml");
                    xmlDoc.Save(Application.StartupPath + "/imageStore.xml");
                }
                else
                {
                    xmlDoc.Save(Application.StartupPath + "/imageStore.xml");
                }
    
                //return true;
            }//end of writeXml
