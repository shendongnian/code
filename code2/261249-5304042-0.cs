    foreach (System.Xml.Schema.XmlSchemaComplexType item in xmlSchema.SchemaTypes.Values)
            {
                ComplexType cType = new ComplexType(item.Name);
                System.Xml.Schema.XmlSchemaContentModel model = item.ContentModel;
                System.Xml.Schema.XmlSchemaComplexContent complex = model as System.Xml.Schema.XmlSchemaComplexContent;
                if (complex != null)
                {
                    System.Xml.Schema.XmlSchemaComplexContentExtension extension = complex.Content as System.Xml.Schema.XmlSchemaComplexContentExtension;
                    System.Xml.Schema.XmlSchemaParticle particle = extension.Particle;
                    System.Xml.Schema.XmlSchemaSequence sequence = particle as System.Xml.Schema.XmlSchemaSequence;
                    if (sequence != null)
                    {
                        List<SimpleType> primitives = new List<SimpleType>(); 
                        foreach (System.Xml.Schema.XmlSchemaElement childElement in sequence.Items)
                        {
                            string name = childElement.Name;
                            string type = childElement.SchemaTypeName.Name;
                            cType.Primitives.Add(new SimpleType(name, type));
                        }
                        if (cType.Name == parameter.Type || "ArrayOf" + cType.Name == parameter.Type)
                        {
                            descriptions.Add(new ComplexParameter(cType, item.Name));
                        }
                    }
                }
            } 
