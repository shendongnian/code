    static public string ToHex(byte[] array)
    {
      var builder = new StringBuilder();
      array = array.Reverse().ToArray();
      for ( int index = 0; index < array.Length; index++ )
      {
        builder.Append(array[index].ToString("X").PadLeft(2, '0') + " ");
      }
      return builder.ToString().TrimEnd();
    }
