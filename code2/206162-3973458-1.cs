        public T LoadContractFromJSON<T>(string filePath)
        {
            try
            {
                string text = File.ReadAllText(filePath);
                text  = Regex.Replace(text, "\\{[\\n\\r ]*\"__type", "{\"__type");
                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(text)))
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                    T contract = (T)serializer.ReadObject(stream);
                    return contract;
                }
            }
            catch (System.Exception ex)
            {
                logger.Error("Cannot deserialize json " + filePath, ex);
                throw;
            }
        }
