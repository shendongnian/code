        public static object Deserialize(string xml)
        {
            var deserializer = new System.Xml.Serialization.XmlSerializer(typeof(RecordXmlConfiguration));
            using (var reader = XmlReader.Create(new StringReader(xml)))
            {
                return (RecordXmlConfiguration)deserializer.Deserialize(reader);
            }
        }
