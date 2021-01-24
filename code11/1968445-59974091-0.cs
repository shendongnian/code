        public static StreamReader _StreamReader(string filePath)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    throw new InvalidOperationException();
                }
                return new StreamReader(filePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void _Serialize<T>(string filePath, T object)
        {
            try
            {
                var xmlSerializer = new XmlSerializer(object.GetType());
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    xmlSerializer.Serialize(fileStream, object);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static T _UnSerialize<T>(StreamReader streamReader)
        {
            try
            {
                T deserializedObject = default(T);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                deserializedObject = (T)xmlSerializer.Deserialize(streamReader);
                streamReader.Dispose();
                return deserializedObject;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
