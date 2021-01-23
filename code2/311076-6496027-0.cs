    public static byte[] Object2ByteArray(object o)
    {
    
        MemoryStream ms = new MemoryStream();
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(ms, o);
        return ms.ToArray();
    
    }
