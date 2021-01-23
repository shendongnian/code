    public static int GetLength(CryptoStream cs, out byte[] data)
    {
        var length = 0;
        var bytes = new List<byte>();
        while (true)
        {
            var b = cs.ReadByte();
            if (b == -1)
            {
                break;
            }
            length++;
            bytes.Add((byte)b);
        }
        data = bytes.ToArray();
        return length;
    }
