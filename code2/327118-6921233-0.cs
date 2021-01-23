    public static int BytesToIntUsingBitConverter(byte b0, byte b1, byte b2, byte b3)
    {
      var byteArray = BitConverter.IsLittleEndian ? new byte[] { b3, b2, b1, b0 } : new byte[] { b0, b1, b2, b3 };
      return BitConverter.ToInt32(byteArray, 0);
    }
