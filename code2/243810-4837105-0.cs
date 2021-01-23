        public void serializesample<T>(T sample) {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            string path = "G:\\sample.xml";
            Stream st = new FileStream(path, FileMode.OpenOrCreate);
            XmlWriter w = new XmlTextWriter(st, Encoding.UTF8);
            serializer.Serialize(w, sample);
            st.Flush();
            st.Close();
        }
        private T ReadObject<T>(XmlReader reader) {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(reader);
        }
