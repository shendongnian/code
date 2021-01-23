    public static byte[] ToByteArray(String HexString)
    {
       string hex_no_spaces = HexString.Replace(" ","");
       int NumberChars = hex_no_spaces.Length;
       byte[] bytes = new byte[NumberChars / 2];
       for (int i = 0; i < NumberChars; i+=2)
       {
          bytes[i / 2] = byte.Parse(hex_no_spaces.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
       }
       return bytes;
    }
