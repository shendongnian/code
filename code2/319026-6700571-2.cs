    public static byte[] Serialize(object obj)
    {
        Type type = obj.GetType();
        DataContractSerializer dcs = new DataContractSerializer(type);
        using (var stream = new MemoryStream())
        {
            dcs.WriteObject(stream, obj);
            return stream.ToArray();
        }
    }
