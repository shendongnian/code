        static void Main(string[] args)
        {
            var reader = XmlReader.Create(@"c:\x.xml");
            var schemaSet = new XmlSchemaSet();
            var schema = new XmlSchemaInference();
            schemaSet = schema.InferSchema(reader);
            foreach (var element in
                schemaSet.Schemas().Cast<XmlSchema>().SelectMany(s => s.Elements.Values.Cast<XmlSchemaElement>()))
            {
                Debug.WriteLine(element.Name + " (element)");
                iterateOverElement(element.Name, element);
            }
        }
        private static void iterateOverElement(string root, XmlSchemaElement element)
        {
            var complexType = element.ElementSchemaType as XmlSchemaComplexType;
            if (complexType == null) return;
            if (complexType.AttributeUses.Count > 0)
            {
                var enumerator = complexType.AttributeUses.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    var attribute = (XmlSchemaAttribute)enumerator.Value;
                    Debug.WriteLine(root + "." + attribute.Name + " (attribute)");
                }
            }
            var sequence = complexType.ContentTypeParticle as XmlSchemaSequence;
            if (sequence == null) return;
            foreach (XmlSchemaElement childElement in sequence.Items)
            {
                Debug.WriteLine(root + "." + childElement.Name + " (element)");
                // recursion
                iterateOverElement(String.Concat(root, ".", childElement.Name), childElement);
            }
        }
