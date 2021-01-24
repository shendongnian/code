    using (XmlReader schemaReader = XmlReader.Create(new StringReader(the_schema_as_string)))
            {
                XmlSchemaSet schemaSet = new XmlSchemaSet();
                schemaSet.Add(XmlSchema.Read(schemaReader, null));
                var xsdAsXDoc = XDocument.Load(new StringReader(the_schema_as_string));
                var ns = XNamespace.Get(@"http://www.w3.org/2001/XMLSchema");
                foreach (XmlSchemaElement element in schemaSet.Schemas()
                    .Cast<XmlSchema>()
                    .SelectMany(s => s.Elements.Values.Cast<XmlSchemaElement>()))
                {
                    GetFieldMaxLengthValue(element, xsdAsXDoc, ns);
                }
            }
