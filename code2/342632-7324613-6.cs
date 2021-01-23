       /// <param name="path">your XML file</param>
        static void printSchema(string path)
        {
            var schemaSet = new XmlSchemaInference().InferSchema(XmlReader.Create(path));
            foreach (var element in
                schemaSet.Schemas().Cast<XmlSchema>().SelectMany(s => s.Elements.Values.Cast<XmlSchemaElement>()))
            {
                Debug.WriteLine(element.Name + " (element)");
                iterateOverElement(element.Name, element);
            }
        }
        static void iterateOverElement(string root, XmlSchemaElement element)
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
                root += String.Concat(".", childElement.Name);
                Debug.WriteLine(root + " (element)");
                // recursion
                iterateOverElement(root, childElement);
            }
