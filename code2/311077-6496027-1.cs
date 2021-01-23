    public static byte[] Object2ByteArray(object o)
    {
        using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = 
                new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            bf.Serialize(ms, o);
            return ms.ToArray();
        }
    }
