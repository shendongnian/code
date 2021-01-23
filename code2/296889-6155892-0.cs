    public static byte[] ToBytesFromHexa(string text)
    {
        if (text == null)
            throw new ArgumentNullException("text");
			List<byte> bytes = new List<byte>();
        bool low = false;
        byte prev = 0;
        for (int i = 0; i < text.Length ; i++)
        {
            byte b = GetHexaByte(text[i]);
            if (b == 0xFF)
                continue;
            if (low)
            {
                bytes.Add((byte)(prev * 16 + b));
            }
            else
            {
                prev = b;
            }
            low = !low;
        }
        return bytes.ToArray();
    }
    public static byte GetHexaByte(char c)
    {
        if ((c >= '0') && (c <= '9'))
            return (byte)(c - '0');
        if ((c >= 'A') && (c <= 'F'))
            return (byte)(c - 'A' + 10);
        if ((c >= 'a') && (c <= 'f'))
            return (byte)(c - 'a' + 10);
        return 0xFF;
    }
