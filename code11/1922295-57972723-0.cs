    public static object PrepareObjectFromString<T>(string json)
        {
            DataContractJsonSerializer dataContractSerializer = new DataContractJsonSerializer(typeof(T));
            using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var deSerializedUser = dataContractSerializer.ReadObject(memoryStream);
                return deSerializedUser;
            }
        }
