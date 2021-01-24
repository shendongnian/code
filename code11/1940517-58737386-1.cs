    static public string ToHex(byte[] array)
    {
      var builder = new StringBuilder();
      for ( int index = array.Length - 1; index >= 0; index-- )
      {
        builder.Append(array[index].ToString("X").PadLeft(2, '0') + " ");
      }
      return builder.ToString().TrimEnd();
    }
