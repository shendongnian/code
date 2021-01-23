    int offset = 0;
    for (int i = 0; i < list.Count; i++)
    {
        long num = BitConverter.DoubleToInt64Bits(list[i]);
        for (int j = 0; j < 8; j++)
        {
            res[offset++] = (byte)num;
            num >>= 8;
        }
    }
