    const string chars = "0123456789abcdefghijklmnopqrstuvwxyz";
    public static byte[] FromBaseN(string str, string chars) {
        // This should be the maximum length of the byte[] array. It's the opposite of the one used
        // in ToBaseN.
        int len = (int)Math.Ceiling(str.Length * Math.Log(chars.Length, 2) / 8);
        var bytes = new List<byte>(len);
        // We strip initial characters that are 'zeros'.
        int i = 0;
        while (i < str.Length && str[i] == chars[0]) {
            i++;
            bytes.Add(0);
        }
        // If the string was composed only of 'zeros', we have finished.
        if (i == str.Length) {
            return bytes.ToArray();
        }
        BigInteger bi = BigInteger.Zero;
        BigInteger length = chars.Length;
        BigInteger mult = BigInteger.One;
        for (int j = str.Length - 1; j >= i; j--) {
            int ix = chars.IndexOf(str[j]);
            // We didn't find the character
            if (ix == -1) {
                throw new ArgumentOutOfRangeException();
            }
            bi += ix * mult;
            mult *= length;
        }
        var bytes2 = bi.ToByteArray();
        for (int j = bytes2[bytes2.Length - 1] == 0 ? bytes2.Length - 2 : bytes2.Length - 1; j >= 0; j--) {
            bytes.Add(bytes2[j]);
        }
        return bytes.ToArray();
    }
    public static string ToBaseN(byte[] bytes, string chars) {
        if (bytes.Length == 0) {
            return String.Empty;
        }
        // We try to pre-calc the length of the string. We know the bits of "information"
        // of a byte are 8. Using Log2 we calc the bits of information of our new base. 
        int len = (int)Math.Ceiling(bytes.Length * 8 / Math.Log(chars.Length, 2));
        StringBuilder sb = new StringBuilder(len);
        // We strip initial bytes set to 0. This because 01 == 1, but we are working on
        // binary data, so the initial zeros are important! We will save these zeros "manually"
        int i = 0;
        while (i < bytes.Length && bytes[i] == 0) {
            i++;
        }
            
        // If the byte array was composed only of zeros, we have finished.
        if (i == bytes.Length) {
            sb.Append(chars[0], i);
            return sb.ToString();
        }
        int newLength = bytes.Length - i;
        // BigInteger saves in the last byte the sign. > 7F negative, <= 7F positive. 
        // If we have a "negative" number, we will prepend a 0 byte.
        // (Here we are working with a pre-Reverse array, so we have to look at the 
        // first byte that will be copied)
        if (bytes[i] > 0x7F) {
            newLength++;
        }
        var bytes2 = new byte[newLength];
        // We reverse the array (and we strip the initial zeros)
        for (int j = bytes.Length - 1, k = 0; j >= i; j--, k++) {
            bytes2[k] = bytes[j];
        }
        BigInteger bi = new BigInteger(bytes2);
        // A little optimization. We will do many divisions based on chars.Length
        BigInteger length = chars.Length;
        while (bi > 0) {
            BigInteger remainder;
            bi = BigInteger.DivRem(bi, length, out remainder);
            sb.Append(chars[(int)remainder]);
        }
        // We append the zeros that we skipped at the beginning
        sb.Append(chars[0], i);
        // We reverse the StringBuilder
        int length2 = sb.Length / 2;
        for (int j = 0, k = sb.Length - 1; j < length2; j++, k--) {
            char ch = sb[j];
            sb[j] = sb[k];
            sb[k] = ch;
        }
        return sb.ToString();
    }
