          public static List<XmlSchemaObject> XsdExpectedElements(XmlSchemaSet schemaSet,
                        List<NodeDescriptor> nodePath)
          {
            List<XmlSchemaObject> elementNames = new List<XmlSchemaObject>();          
            NameTable nt = new NameTable();
            XmlNamespaceManager manager = new XmlNamespaceManager(nt);
            XmlSchemaValidator validator = new XmlSchemaValidator(nt, schemaSet, manager, XmlSchemaValidationFlags.None);
            // event handler sets validationErrorFound local field
            validator.ValidationEventHandler += new ValidationEventHandler(validator_ValidationEventHandler);
            validator.Initialize();
            XmlSchemaInfo xsInfo = new XmlSchemaInfo();
            int i = 0;
            foreach (nodeDescriptor nameUri in nodePath)
            {
                validator.ValidateElement(nameUri.LocalName, nameUri.NamespaceUri, xsInfo);
                if ((i >= siblingPosition && siblingPosition > -1) || nameUri.Closed)
                {
                    validator.SkipToEndElement(null);
                }
                else
                {
                    validator.ValidateEndOfAttributes(null);
                }
                i++;
            }
            XmlSchemaParticle[] parts = validator.GetExpectedParticles();
            if (parts.Length == 0)
            {
                bool hasElements = true;
                bool elementClosed = nodePath[nodePath.Count - 1].Closed;
                if (elementClosed) // we're outside the element tags
                {
                    hasElements = true;
                }
                else if (xsInfo.SchemaType is XmlSchemaSimpleType)
                {
                    hasElements = false;
                }
                else
                {
                    XmlSchemaComplexType xsCt = xsInfo.SchemaType as XmlSchemaComplexType;
                    XmlSchemaContentType xsContent = (XmlSchemaContentType)xsCt.ContentType;
                    if (xsContent == XmlSchemaContentType.TextOnly)
                    {
                        hasElements = false;
                    }
                }
                if (!hasElements)
                {
                    expectedType = XmlEditor.expectedListType.elementValue;
                    if (xsInfo.SchemaElement != null)
                    {
                        elementNames.Add(xsInfo.SchemaElement);
                    }
                }
                return elementNames;
            }
            foreach (XmlSchemaObject xso in parts)
            {
                if (xso is XmlSchemaElement)
                {
                    XmlSchemaElement xse = (XmlSchemaElement)xso;
                    if (subGroupList.ContainsKey(xse.QualifiedName))
                    {
                        List<XmlSchemaElement> xses = subGroupList[xse.QualifiedName];
                        foreach (XmlSchemaElement xseInstance in xses)
                        {
                            elementNames.Add(xseInstance);
                        }
                    }
                    else
                    {
                        elementNames.Add(xse);
                    }
                }
                else if (xso is XmlSchemaAny)
                {
                    XmlSchemaAny xsa = (XmlSchemaAny)xso;
                    foreach (XmlSchema xs in schemaSet.Schemas())
                    {
                        if (xs.TargetNamespace == xsa.Namespace)
                        {
                            foreach (XmlSchemaElement xseAny in xs.Elements)
                            {
                                elementNames.Add(xseAny);
                            }
                        }
                    }
                }
            }
        }
