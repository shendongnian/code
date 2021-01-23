            // parse the original document and retrieve its entities
            XmlDocument parsedXmlDocument = new XmlDocument();
            XmlUrlResolver resolver = new XmlUrlResolver();
            resolver.Credentials = CredentialCache.DefaultCredentials;
            parsedXmlDocument.XmlResolver = resolver;
            parsedXmlDocument.Load(path);
            // create a temporary xml document with all the entities and add references to them
            // the references can then be used to retrieve the value for each entity
            XmlDocument entitiesXmlDocument = new XmlDocument();
            XmlDeclaration dec = entitiesXmlDocument.CreateXmlDeclaration("1.0", null, null);
            entitiesXmlDocument.AppendChild(dec);
            XmlDocumentType newDocType = entitiesXmlDocument.CreateDocumentType(parsedXmlDocument.DocumentType.Name, parsedXmlDocument.DocumentType.PublicId, parsedXmlDocument.DocumentType.SystemId, parsedXmlDocument.DocumentType.InternalSubset);
            entitiesXmlDocument.AppendChild(newDocType);
            XmlElement root = entitiesXmlDocument.CreateElement("xmlEntitiesDoc");
            entitiesXmlDocument.AppendChild(root);
            XmlNamedNodeMap entitiesMap = entitiesXmlDocument.DocumentType.Entities;
            
            // build a dictionary of entity names and values
            Dictionary<string, string> entitiesDictionary = new Dictionary<string, string>();
            for (int i = 0; i < entitiesMap.Count; i++)
            {
                XmlElement entityElement = entitiesXmlDocument.CreateElement(entitiesMap.Item(i).Name);
                XmlEntityReference entityRefElement = entitiesXmlDocument.CreateEntityReference(entitiesMap.Item(i).Name);
                entityElement.AppendChild(entityRefElement);
                root.AppendChild(entityElement);
                if (!string.IsNullOrEmpty(entityElement.ChildNodes[0].InnerXml))
                {
                    // do not add parameter entities or invalid entities
                    // this can be determined by checking for an empty string
                    entitiesDictionary.Add(entitiesMap.Item(i).Name, entityElement.ChildNodes[0].InnerXml);
                }
            }
