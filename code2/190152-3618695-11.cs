        static T DeserializeObject<T>(string fileName) where T : class
        {
            using (FileStream fs = File.OpenRead(fileName))
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                return (T)ser.Deserialize(fs);
            }
        }
