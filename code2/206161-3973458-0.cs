        public void SaveContractToJSON<T>(T contract, string filePath)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                serializer.WriteObject(stream, contract);
                string json = Encoding.UTF8.GetString(stream.ToArray());
                File.WriteAllText(filePath, json.IndentJSON());
            }
        }
