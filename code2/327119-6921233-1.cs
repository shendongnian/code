    public static byte[] CharToBytesUsingBitConverter(char c)
    {
      byte[] byteArray = BitConverter.GetBytes(c);
      return BitConverter.IsLittleEndian ? new byte[] { byteArray[1], byteArray[0] } : byteArray;
    }
