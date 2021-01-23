    public static byte[] GetBytesFromString(string Input, int start, int NumBytes)
    {
        StringBuilder g = new StringBuilder(Input);
        byte[] Bytes = new byte[NumBytes];
        string temp;
        int CharPos = start;
        for (int i = 0; i < NumBytes; i++)
        {
            temp = g[CharPos++].ToString();
            temp += g[CharPos++].ToString();
            Bytes[i] =  byte.Parse(temp, System.Globalization.NumberStyles.HexNumber);
        }
        return Bytes;
    }
