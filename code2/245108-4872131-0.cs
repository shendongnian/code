    private long getSize(byte[][] arr)
    {
        Dictionary<byte[], bool> lookup = new Dictionary<byte[], bool>();
        int size = 0;
        foreach (var innerArray in arr)
        {
            if (lookup.ContainsKey(innerArray)) continue;
            lookup.Add(innerArray, true);
            size += Buffer.ByteLength(innerArray);
        }
        return size;
    }
