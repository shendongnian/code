    public static int GetLength(CryptoStream cs, out byte[] data)
    {
        var bytes = new List<byte>();
        int b;
        while ((b = cs.ReadByte()) != -1)
            bytes.Add((byte)b);
        data = bytes.ToArray();
        return data.Length;
    }
