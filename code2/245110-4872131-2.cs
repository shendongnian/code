    private long getSize(byte[][] arr)
    {
        Dictionary<byte[], bool> lookup = new Dictionary<byte[], bool>();
        long size = 0;
        foreach (byte[] innerArray in arr)
        {
            if (innerArray == null || lookup.ContainsKey(innerArray)) continue;
            lookup.Add(innerArray, true);
            size += Buffer.ByteLength(innerArray);
        }
        return size;
    }
