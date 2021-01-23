    public void SerializeDataValue(List<DataValues> values)
    {
        DataContractSerializer serializer = new DataContractSerializer(typeof(List<DataValues>));
        using (MemoryStream stream = new MemoryStream())
        {
            using (GZipStream compress = new GZipStream(stream, CompressionMode.Compress))
            {
                XmlDictionaryWriter w = XmlDictionaryWriter.CreateBinaryWriter(compress);
                serializer.WriteObject(w, values);
            }
            _serializedData = stream.ToArray();
        }
    }
