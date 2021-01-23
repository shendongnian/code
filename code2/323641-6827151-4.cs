        private List<string> ExpectedEnumValues(XmlSchemaObject xsso)
        {
            XmlSchemaSimpleType xst = null;
            XmlSchemaComplexType xsCt = null;
            List<string> values = new List<string>();
            if (xsso == null)
            {
                return values;
            }
            if (xsso is XmlSchemaAttribute)
            {
                XmlSchemaAttribute xsa = (XmlSchemaAttribute)xsso;
                xst = xsa.AttributeSchemaType;
            }
            else
            {
                XmlSchemaElement xse = (XmlSchemaElement)xsso;
                XmlSchemaType gxst = xse.ElementSchemaType;
                if (gxst is XmlSchemaSimpleType)
                {
                    xst = (XmlSchemaSimpleType)gxst;
                }
                else if (gxst is XmlSchemaComplexType)
                {
                    xsCt = (XmlSchemaComplexType)gxst;
                }
                else
                {
                    return values;
                }
            }
            if(xst != null)
            {
                if (xst.TypeCode == XmlTypeCode.Boolean)
                {
                    values.Add("true");
                    values.Add("false");
                }
                else
                {
                    ProcessXmlSimpleType(xst, values);
                }
            }
            else if (xsCt != null)
            {
                XmlSchemaContentType xsContent = (XmlSchemaContentType) xsCt.ContentType;
                XmlSchemaContentModel xsModel = (XmlSchemaContentModel)xsCt.ContentModel;
                if (xsModel is XmlSchemaSimpleContent)
                {
                    XmlSchemaSimpleContent xsSC = (XmlSchemaSimpleContent)xsModel;
                    XmlSchemaContent xsRE = xsSC.Content;
                    if (xsRE != null)
                    {
                        if (xsRE is XmlSchemaSimpleContentRestriction)
                        {
                            XmlSchemaSimpleContentRestriction xsCCR = (XmlSchemaSimpleContentRestriction)xsRE;
                            foreach (XmlSchemaObject xso in xsCCR.Facets)
                            {
                                if (xso is XmlSchemaEnumerationFacet)
                                {
                                    XmlSchemaEnumerationFacet xsef = (XmlSchemaEnumerationFacet)xso;
                                    values.Add(xsef.Value);
                                }
                            }
                        }
                    }
                }
                else
                {
                    XmlSchemaComplexContent xsCC = (XmlSchemaComplexContent)xsModel;
                    XmlSchemaContent xsRE = xsCC.Content;
                    if (xsRE != null)
                    {
                        if (xsRE is XmlSchemaComplexContentRestriction)
                        {
                            XmlSchemaComplexContentRestriction xsR = (XmlSchemaComplexContentRestriction)xsRE;
                        }
                        else if (xsRE is XmlSchemaComplexContentExtension)
                        {
                            XmlSchemaComplexContentExtension xsE = (XmlSchemaComplexContentExtension)xsRE;
                        }
                    }
                }
                
                
            }
            return values;
        }
