    public static float HexToFloat(string hexVal)
    {
        byte[] data = new byte[hexVal.Length / 2];
        for (int i = 0; i < data.Length; ++i)
        {
            data[i] = Convert.ToByte(hexVal.Substring(i * 2, 2), 16);
        }
        return BitConverter.ToSingle(data, 0);
    }
