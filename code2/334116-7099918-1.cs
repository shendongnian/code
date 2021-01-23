        public static T DeserializeObject<T>(string xml)
        {
            using (StringReader rdr = new StringReader(xml))
            {
                return (T)new XmlSerializer(typeof(T)).Deserialize(rdr);
            }
        }
