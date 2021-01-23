    byte[] convertToBytes(string s)
    {
        byte[] result = new byte[(s.Length + 7) / 8];
        int i = 0;
        int j = 0;
        foreach (char c in s)
        {
            result[i] <<= 1;
            if (c == '1')
                result[i] |= 1;
            j++;
            if (j == 8)
            {
                i++;
                j = 0;
            }
        }
        return result;
    }
