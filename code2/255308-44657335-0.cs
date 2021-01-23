        private static string CreateXMLString(object o)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(object));
            var stringBuilder = new StringBuilder();
            using (var writer = XmlWriter.Create(stringBuilder))
            {
                serializer.Serialize(writer, o);
            }
            return stringBuilder.ToString();
        }
