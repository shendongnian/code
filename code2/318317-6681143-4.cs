    public static T DeserializeForXml<T>(string filePath)
        {
            XmlSerializer selializer = new XmlSerializer(typeof(T));
            using (Stream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return (T)selializer.Deserialize(fs);
            }
        }
