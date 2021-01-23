        internal static FormField Deserialize(string xml)
        {
            var serializer = new DataContractSerializer(typeof(FormFieldContainer));
            using (var backing = new StringReader(xml))
            {
                using (var reader = new XmlTextReader(backing))
                {
                    return ((FormFieldContainer)serializer.ReadObject(reader)).FormField;
                }
            }
        }
