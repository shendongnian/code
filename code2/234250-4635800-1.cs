    static float[] ConvertByteArrayToFloat(byte[] bytes)
    {
        if(bytes == null)
            throw new ArgumentNullException("bytes");
       if(bytes.Length % 4 != 0)
            throw new ArgumentException
                  ("bytes does not represent a sequence of floats");
        return Enumerable.Range(0, bytes.Length / 4)
                         .Select(i => BitConverter.ToSingle(bytes, i * 4))
                         .ToArray();
    }
