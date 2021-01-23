        public static void WriteElement(XmlWriter writer, string name, object value)
        {
            writer.WriteStartElement(name);
            var serializer = new XmlSerializer(value.GetType());
            serializer.Serialize(writer, value);
            writer.WriteEndElement();
        }
