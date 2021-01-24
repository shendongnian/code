    public RootObject Deserialize(byte[] bytes)
    {
        var hexUtf8 = Encoding.UTF8.GetString(bytes);
        var bytesUtf8 = HexStringToByteArray(hexUtf8);
                
        var serializer = MessagePackSerializer.Get<RootObject>();
        var stream = new MemoryStream(bytesUtf8);
        return serializer.Unpack(stream);
    }
    
    public static byte[] HexStringToByteArray(this string hex)
    {
        var result = new byte[hex.Length / 2];
        for (var i = 0; i < result.Length; i++)
        {
            result[i] = System.Convert.ToByte(hex.Substring(i * 2, 2), 16);
        }
        return result;
    }
