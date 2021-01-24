    public byte[] ToBytes()
    {
        List<byte> result = new List<byte>();
        // ...
        result.AddRange(BitConverter.GetBytes(timestamp));
        // ...
        return result.ToArray();
    }
