        public static void WriteElement(XmlWriter writer, string name, object value)
        {
            var serializer = new XmlSerializer(value.GetType(), new XmlRootAttribute(name));
            serializer.Serialize(writer, value);
        }
