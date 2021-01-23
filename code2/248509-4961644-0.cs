    public void SerializeDataValue(List<DataValues> values)
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(List<DataValues>));
                        using (MemoryStream stream = new MemoryStream())
                    {
                        using (GZipStream compress = new GZipStream(stream, CompressionMode.Compress))
                        {
                            serializer.WriteObject(compress , values);
    
                        }
                        _serializedData = stream.ToArray();
                    }
                }
        
        public List<DataValues> DeserializeDataValue()
        {
            if (SerializedData == null || SerializedData.Length == 0)
            {
                return new List<DataValues> ();
            }
            else
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<DataValues>));
                using (MemoryStream stream = new MemoryStream(SerializedData))
                {
                    using (GZipStream decompress = new GZipStream(stream, CompressionMode.Decompress))
                    {
                        return serializer.ReadObject(decompress , true) as List<DataValues>;
                    }
                }
            }
        }
