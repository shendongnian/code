        TextWriter writer = null;
            
                        try
                        {
                            XmlDocument doc = new XmlDocument();
            
                            //xml decleration
                            var xmlDecleration = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
            
                            doc.AppendChild(xmlDecleration);
            
                            //create the 
                            XmlElement rootElement = doc.CreateElement("datatableTopLevelElement");//, HierachyFileConstants.EXPORT_NAMESPACE);//the root element
                            XmlAttribute versionAttribute = doc.CreateAttribute("someVersionAttribute");
                            versionAttribute.Value = Version;//set the version number
                            rootElement.Attributes.Append(versionAttribute);
            
                            doc.AppendChild(rootElement);
        
        XmlElement dataObjectType = doc.CreateElement("FirstDataTable");//element name
        
        using (var ms = new MemoryStream())
                                {
                                    var serializer = new XmlSerializer(dataType.GetType());//datatable type(if you know it)
                                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                                    ns.Add("", "");
                                    writer = new StreamWriter(ms);
                                    serializer.Serialize(writer, dataType, ns);
        
                                    //for some reason using xmlSettings with UTF-8 encoding creates an extra unecessary character
        
                                    //remove first line of xml file
                                    var xmlData = string.Join(Environment.NewLine, Encoding.UTF8.GetString(ms.ToArray())
                                        .Split(Environment.NewLine.ToCharArray())
                                        .Skip(1)
                                        .ToArray());
        
                                    var xmlElement = GetElement(xmlData);
        
                                    dataObjectType.AppendChild(dataObjectType.OwnerDocument.ImportNode(xmlElement, true));
                                }
    
    //end of first datatable -- repeat from first datable method to add second datatable(
         }
                            }
        
                        }
        
                        //var tes
                        //return new XmlDocument().LoadXml(doc.OuterXml.Replace("xmlns=\"" + string.Empty + "\"",string.Empty));
                        var docToReturn = new XmlDocument();
                        docToReturn.LoadXml(doc.OuterXml.Replace("xmlns=\"" + string.Empty + 
    
        "\"", string.Empty));
                            return docToReturn;
        }
    
    
    The GetElement method looks like this 
    
        private XmlElement GetElement(string xml)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(xml);
                    doc.DocumentElement.Attributes.RemoveNamedItem("xmlns");
                    //doc.DocumentElement.NamespaceURI
                    return doc.DocumentElement;
                }
