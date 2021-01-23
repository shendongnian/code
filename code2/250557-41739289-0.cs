        public IList<Object> Deserialize(string a_fileName)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Object>));
            TextReader reader = new StreamReader(a_fileName);
            object obj = deserializer.Deserialize(reader);
            reader.Close();
            return (List<Object>)obj;
        }
        public void Serialization(IList<Object> a_stations,string a_fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Object>));
            using (var stream = File.OpenWrite(a_fileName))
            {
                serializer.Serialize(stream, a_stations);
            }
        }
        
