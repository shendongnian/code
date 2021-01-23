        private static void ProcessXmlSimpleType(XmlSchemaSimpleType xst, List<string> values)
        {
            if (xst == null)
            {
                return;
            }
            XmlSchemaSimpleTypeContent xsstc = xst.Content;
            if (xsstc is XmlSchemaSimpleTypeRestriction)
            {
                XmlSchemaSimpleTypeRestriction xsr = (XmlSchemaSimpleTypeRestriction)xsstc;
                XmlSchemaObjectCollection xsoc = xsr.Facets;
                XmlSchemaSimpleType bastTypeOfRestiction = xsr.BaseType;
                foreach (XmlSchemaObject xso in xsoc)
                {
                    if (xso is XmlSchemaEnumerationFacet)
                    {
                        XmlSchemaEnumerationFacet xsef = (XmlSchemaEnumerationFacet)xso;
                        values.Add(xsef.Value);
                    }
                }
            }
            else if (xsstc is XmlSchemaSimpleTypeList)
            {
                XmlSchemaSimpleTypeList xsstL = (XmlSchemaSimpleTypeList)xsstc;
                XmlSchemaSimpleType xstL = xsstL.BaseItemType;
                ProcessXmlSimpleType(xstL, values); // recursive
            }
            else if (xsstc is XmlSchemaSimpleTypeUnion)
            {
                XmlSchemaSimpleTypeUnion xstU = (XmlSchemaSimpleTypeUnion)xsstc;
                XmlSchemaSimpleType[] xsstArray = xstU.BaseMemberTypes;
                foreach (XmlSchemaSimpleType xsstA in xsstArray)
                {
                    ProcessXmlSimpleType(xsstA, values); // recursive
                }
            }
        }
