    const string chars = "0123456789abcdefghijklmnopqrstuvwxyz";
    // The result is padded with chars[0] to make the string length
    // (int)Math.Ceiling(bytes.Length * 8 / Math.Log(chars.Length, 2))
    // (so that for any value [0...0]-[255...255] of bytes the resulting
    // string will have same length)
    public static string ToBaseN(byte[] bytes, string chars, bool littleEndian = true, int len = -1)
    {
        if (bytes.Length == 0 || len == 0)
        {
            return String.Empty;
        }
        // BigInteger saves in the last byte the sign. > 7F negative, 
        // <= 7F positive. 
        // If we have a "negative" number, we will prepend a 0 byte.
        byte[] bytes2;
        if (littleEndian)
        {
            if (bytes[bytes.Length - 1] <= 0x7F)
            {
                bytes2 = bytes;
            }
            else
            {
                // Note that Array.Resize doesn't modify the original array,
                // but creates a copy and sets the passed reference to the
                // new array
                bytes2 = bytes;
                Array.Resize(ref bytes2, bytes.Length + 1);
            }
        }
        else
        {
            bytes2 = new byte[bytes[0] > 0x7F ? bytes.Length + 1 : bytes.Length];
            // We copy and reverse the array
            for (int i = bytes.Length - 1, j = 0; i >= 0; i--, j++)
            {
                bytes2[j] = bytes[i];
            }
        }
        BigInteger bi = new BigInteger(bytes2);
        // A little optimization. We will do many divisions based on 
        // chars.Length .
        BigInteger length = chars.Length;
        // We pre-calc the length of the string. We know the bits of 
        // "information" of a byte are 8. Using Log2 we calc the bits of 
        // information of our new base. 
        if (len == -1)
        {
            len = (int)Math.Ceiling(bytes.Length * 8 / Math.Log(chars.Length, 2));
        }
        // We will build our string on a char[]
        var chs = new char[len];
        int chsIndex = 0;
        while (bi > 0)
        {
            BigInteger remainder;
            bi = BigInteger.DivRem(bi, length, out remainder);
            chs[littleEndian ? chsIndex : len - chsIndex - 1] = chars[(int)remainder];
            chsIndex++;
            if (chsIndex < 0)
            {
                if (bi > 0)
                {
                    throw new OverflowException();
                }
            }
        }
        // We append the zeros that we skipped at the beginning
        if (littleEndian)
        {
            while (chsIndex < len)
            {
                chs[chsIndex] = chars[0];
                chsIndex++;
            }
        }
        else
        {
            while (chsIndex < len)
            {
                chs[len - chsIndex - 1] = chars[0];
                chsIndex++;
            }
        }
        return new string(chs);
    }
    public static byte[] FromBaseN(string str, string chars, bool littleEndian = true, int len = -1)
    {
        if (str.Length == 0 || len == 0)
        {
            return new byte[0];
        }
        // This should be the maximum length of the byte[] array. It's 
        // the opposite of the one used in ToBaseN.
        // Note that it can be passed as a parameter
        if (len == -1)
        {
            len = (int)Math.Ceiling(str.Length * Math.Log(chars.Length, 2) / 8);
        }
        BigInteger bi = BigInteger.Zero;
        BigInteger length2 = chars.Length;
        BigInteger mult = BigInteger.One;
        for (int j = 0; j < str.Length; j++)
        {
            int ix = chars.IndexOf(littleEndian ? str[j] : str[str.Length - j - 1]);
            // We didn't find the character
            if (ix == -1)
            {
                throw new ArgumentOutOfRangeException();
            }
            bi += ix * mult;
            mult *= length2;
        }
        var bytes = bi.ToByteArray();
        int len2 = bytes.Length;
        // BigInteger adds a 0 byte for positive numbers that have the
        // last byte > 0x7F
        if (len2 >= 2 && bytes[len2 - 1] == 0)
        {
            len2--;
        }
        int len3 = Math.Min(len, len2);
        byte[] bytes2;
        if (littleEndian)
        {
            if (len == bytes.Length)
            {
                bytes2 = bytes;
            }
            else
            {
                bytes2 = new byte[len];
                Array.Copy(bytes, bytes2, len3);
            }
        }
        else
        {
            bytes2 = new byte[len];
            for (int i = 0; i < len3; i++)
            {
                bytes2[len - i - 1] = bytes[i];
            }
        }
        for (int i = len3; i < len2; i++)
        {
            if (bytes[i] != 0)
            {
                throw new OverflowException();
            }
        }
        return bytes2;
    }
